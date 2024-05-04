using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication6.BAL;
using WebApplication6.Models;

namespace WebApplication6
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllRecords();
                ShowButtons();
                HideButtons();
                ResetForm();
            }
        }

        private void ShowButtons()
        {
            updateBtn.Enabled = true;
            deleteBtn.Enabled = true;
            insertBtn.Enabled = false;
        }
        private void HideButtons()
        {
            insertBtn.Enabled = true;
            updateBtn.Enabled = false;
            deleteBtn.Enabled = false;
        }

        private void ResetForm()
        {
            txtStudName.Text = string.Empty;
            txtStudFName.Text = string.Empty;
            txtStudEmail.Text = string.Empty;
            txtStudAge.Text = string.Empty;
            txtStudAdd.Text = string.Empty;
            txtStudId.Text = string.Empty;
            txtStudPhone.Text = string.Empty;
            txtStudRegNo.Text = string.Empty;
            txtStudSec.SelectedIndex = 0;
            txtStudClass.SelectedIndex = 0;
            txtStudGen.SelectedIndex = 0;
            txtStatus.SelectedIndex = 0;
            txtStudDoj.Text = string.Empty;
            txtStudRegNo.Focus();
        }

        protected void GetAllRecords()
        {
            BalStud obj = new BalStud();
            List<Student> students = obj.GetStudents();

            foreach (Student student in students)
            {
                student.studPhoto = "~/StudentPhotos/" + student.studPhoto;
            }

            GridView1.DataSource = students;
            GridView1.DataBind();
        }


        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            ShowButtons();
            GridViewRow selectedRow = GridView1.Rows[e.NewSelectedIndex];
            txtStudId.Text = selectedRow.Cells[0].Text;
            txtStudRegNo.Text = selectedRow.Cells[1].Text;
            txtStudName.Text = selectedRow.Cells[2].Text;
            txtStudFName.Text = selectedRow.Cells[3].Text;
            txtStudAdd.Text = selectedRow.Cells[4].Text;
            txtStudPhone.Text = selectedRow.Cells[5].Text;
            txtStudEmail.Text = selectedRow.Cells[6].Text;
            txtStudGen.SelectedValue = selectedRow.Cells[7].Text;
            txtStudAge.Text = selectedRow.Cells[8].Text;
            txtStudDoj.Text = selectedRow.Cells[9].Text;
            txtStudClass.SelectedValue = selectedRow.Cells[10].Text;
            txtStudSec.SelectedValue = selectedRow.Cells[11].Text;
            txtStatus.SelectedValue = selectedRow.Cells[13].Text;
        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {

            if (txtStudPhoto.HasFile)
            {
                string[] supportedImageTypes = { "image/jpeg", "image/png", "image/gif" };
                if (supportedImageTypes.Contains(txtStudPhoto.PostedFile.ContentType))
                {
                    BalStud obj = new BalStud();
                    if (obj.CheckDuplicateRegNo(txtStudRegNo.Text) > 0)
                    {
                        lblMsg.Text = "Registration Number Already Exist !";
                        return;
                    }
                    if (obj.CheckDuplicateEmail(txtStudEmail.Text) > 0)
                    {
                        lblMsg.Text = "Email Already Exist !";
                        return;
                    }
                    Student stud = new Student();
                    string fileName = txtStudPhoto.FileName;
                    stud.studRegNo = txtStudRegNo.Text;
                    stud.studEmail = txtStudEmail.Text;
                    stud.studName = txtStudName.Text;
                    stud.studFName = txtStudFName.Text;
                    stud.studAdd = txtStudAdd.Text;
                    stud.studPhone = txtStudPhone.Text;
                    stud.studGen = txtStudGen.SelectedValue;
                    stud.studAge = txtStudAge.Text;
                    stud.studDoj = txtStudDoj.Text;
                    stud.studClass = txtStudClass.SelectedValue;
                    stud.studSec = txtStudSec.SelectedValue;
                    stud.studPhoto = fileName;
                    stud.status = txtStatus.SelectedValue;
                    obj.InsertStud(stud);
                    txtStudPhoto.SaveAs(Server.MapPath("~/StudentPhotos/" + fileName));
                    GetAllRecords();
                    HideButtons();
                    ResetForm();
                    lblMsg.Text = "Data Inserted";
                }
                else
                {
                    lblMsg.Text = "Please Upload only jpg,jpeg and png file";
                    return;
                }
            }
            else
            {
                lblMsg.Text = "Please select student photo";
                return;
            }

        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            BalStud obj = new BalStud();
            Student stud = new Student();
            stud.studId = Convert.ToInt32(txtStudId.Text);
            stud.studRegNo = txtStudRegNo.Text;
            stud.studEmail = txtStudEmail.Text;
            stud.studName = txtStudName.Text;
            stud.studFName = txtStudFName.Text;
            stud.studAdd = txtStudAdd.Text;
            stud.studPhone = txtStudPhone.Text;
            stud.studGen = txtStudGen.SelectedValue;
            stud.studAge = txtStudAge.Text;
            stud.studDoj = txtStudDoj.Text;
            stud.studClass = txtStudClass.SelectedValue;
            stud.studSec = txtStudSec.SelectedValue;
            stud.status = txtStatus.SelectedValue;
            if (txtStudPhoto.HasFile)
            {
                string[] supportedImageTypes = { "image/jpeg", "image/png", "image/gif" };
                if (supportedImageTypes.Contains(txtStudPhoto.PostedFile.ContentType))
                {
                    string fileName = txtStudPhoto.FileName;
                    stud.studPhoto = fileName;
                    obj.UpdateStud(stud);
                    txtStudPhoto.SaveAs(Server.MapPath("~/StudentPhotos/" + fileName));
                }
                else
                {
                    lblMsg.Text = "Please Upload only jpg,jpeg and png file";
                    return;
                }

            }
            else
            {
                obj.UpdateStudWithOutImg(stud);
            }
            lblMsg.Text = "Data Updated";
            GetAllRecords();
            HideButtons();
            ResetForm();
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            BalStud obj = new BalStud();
            obj.DeleteStud(Convert.ToInt32(txtStudId.Text));
            lblMsg.Text = "Data Deleted";
            GetAllRecords();
            HideButtons();
            ResetForm();
        }

        protected void resetBtn_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        protected void SelecttxtStudDoj_TextChanged(object sender, EventArgs e)
        {
            if (DateTime.TryParse(SelecttxtStudDoj.Text, out DateTime selectedDate))
            {
                txtStudDoj.Text = selectedDate.ToString("dd-MM-yyyy");
                SelecttxtStudDoj.Text = string.Empty;
            }
        }
    
    }
}