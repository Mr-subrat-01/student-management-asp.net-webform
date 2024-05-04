<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication6.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table border="1" align="center">
            <tr>
                <th colspan="4">Student Form</th>
            </tr>
            <tr>
                <td>Enter Registration Number</td>
                <td>
                    <asp:TextBox runat="server" ID="txtStudRegNo"></asp:TextBox>
                    <asp:Label ID="txtStudId" runat="server" Text="" Visible="False"></asp:Label>
                </td>
                <td>Enter Name</td>
                <td>
                    <asp:TextBox runat="server" ID="txtStudName"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Enter Father Name</td>
                <td>
                    <asp:TextBox runat="server" ID="txtStudFName"></asp:TextBox>
                </td>
                <td>Enter Address</td>
                <td>
                    <asp:TextBox runat="server" ID="txtStudAdd"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Enter Phone</td>
                <td>
                    <asp:TextBox runat="server" ID="txtStudPhone"></asp:TextBox>
                </td>
                <td>Enter Email</td>
                <td>
                    <asp:TextBox runat="server" ID="txtStudEmail"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>Enter Age</td>
                <td>
                    <asp:TextBox runat="server" ID="txtStudAge"></asp:TextBox>
                </td>
                <td>Select Date of Joining</td>
                <td>
                    <asp:Label ID="txtStudDoj" runat="server" Text=""></asp:Label>
                    <asp:TextBox ID="SelecttxtStudDoj" runat="server" TextMode="Date" OnTextChanged="SelecttxtStudDoj_TextChanged" AutoPostBack="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Select Class</td>
                <td>
                    <asp:DropDownList ID="txtStudClass" runat="server">
                        <asp:ListItem>Select One</asp:ListItem>
                        <asp:ListItem Value="Class 1">Class 1</asp:ListItem>
                        <asp:ListItem Value="Class 2">Class 2</asp:ListItem>
                        <asp:ListItem Value="Class 3">Class 3</asp:ListItem>
                        <asp:ListItem Value="Class 4">Class 4</asp:ListItem>
                        <asp:ListItem Value="Class 5">Class 5</asp:ListItem>
                        <asp:ListItem Value="Class 6">Class 6</asp:ListItem>
                        <asp:ListItem Value="Class 7">Class 7</asp:ListItem>
                        <asp:ListItem Value="Class 8">Class 8</asp:ListItem>
                        <asp:ListItem Value="Class 9">Class 9</asp:ListItem>
                        <asp:ListItem Value="Class 10">Class 10</asp:ListItem>
                        <asp:ListItem Value="Class 11">Class 11</asp:ListItem>
                        <asp:ListItem Value="Class 12">Class 12</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>Select Section</td>
                <td>
                    <asp:DropDownList ID="txtStudSec" runat="server">
                        <asp:ListItem>Select One</asp:ListItem>
                        <asp:ListItem Value="Sec A">Sec A</asp:ListItem>
                        <asp:ListItem Value="Sec B">Sec B</asp:ListItem>
                        <asp:ListItem Value="Sec C">Sec C</asp:ListItem>
                        <asp:ListItem Value="Sec D">Sec D</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Select Gender</td>
                <td>
                    <asp:RadioButtonList ID="txtStudGen" runat="server" ValidationGroup="Gender">
                        <asp:ListItem Value="M">Male</asp:ListItem>
                        <asp:ListItem Value="F">Female</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>Select Student Status</td>
                <td>
                    <asp:RadioButtonList ID="txtStatus" runat="server" ValidationGroup="status">
                        <asp:ListItem Value="Active">Active</asp:ListItem>
                        <asp:ListItem Value="Inactive">InActive</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>Upload Photo</td>
                <td>
                    <asp:FileUpload ID="txtStudPhoto" runat="server" />
                </td>
                <td>
                    <asp:Button Text="Insert" ID="insertBtn" runat="server" OnClientClick="return Validate()" OnClick="insertBtn_Click" />
                    <asp:Button Text="Update" ID="updateBtn" runat="server" OnClientClick="return Validate()" OnClick="updateBtn_Click" />
                    <asp:Button Text="Delete" ID="deleteBtn" runat="server" OnClientClick="return Validate()" OnClick="deleteBtn_Click" />
                    <asp:Button Text="Reset Form" ID="resetBtn" runat="server" OnClick="resetBtn_Click" />
                </td>
                <td>
                    <asp:Label runat="server" ID="lblMsg"></asp:Label>
                </td>
            </tr>
            <tr align="center">
                <th colspan="4">Student Records</th>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="studId" HeaderText="ID"></asp:BoundField>
                            <asp:BoundField DataField="studRegNo" HeaderText="Registration Number"></asp:BoundField>
                            <asp:BoundField DataField="studName" HeaderText="Name"></asp:BoundField>
                            <asp:BoundField DataField="studFName" HeaderText="Father Name"></asp:BoundField>
                            <asp:BoundField DataField="studAdd" HeaderText="Address"></asp:BoundField>
                            <asp:BoundField DataField="studPhone" HeaderText="Phone"></asp:BoundField>
                            <asp:BoundField DataField="studEmail" HeaderText="Email"></asp:BoundField>
                            <asp:BoundField DataField="studGen" HeaderText="Gender"></asp:BoundField>
                            <asp:BoundField DataField="studAge" HeaderText="Age"></asp:BoundField>
                            <asp:BoundField DataField="studDoj" HeaderText="Date Of Joining"></asp:BoundField>
                            <asp:BoundField DataField="studClass" HeaderText="Class"></asp:BoundField>
                            <asp:BoundField DataField="studSec" HeaderText="Section"></asp:BoundField>
                            <asp:ImageField DataImageUrlField="studPhoto" HeaderText="Image" ControlStyle-CssClass="studimg" ControlStyle-Width="90px" >
                            </asp:ImageField>
                            <asp:BoundField DataField="status" HeaderText="Student Status"></asp:BoundField>
                            <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </form>
   <script>
       function Validate() {
           var txtStudRegNo = document.getElementById("txtStudRegNo");
           var txtStudName = document.getElementById("txtStudName");
           var txtStudFName = document.getElementById("txtStudFName");
           var txtStudAdd = document.getElementById("txtStudAdd");
           var txtStudPhone = document.getElementById("txtStudPhone");
           var txtStudEmail = document.getElementById("txtStudEmail");
           var txtStudAge = document.getElementById("txtStudAge");
           var txtStudDoj = document.getElementById("txtStudDoj");
           var SelecttxtStudDoj = document.getElementById("SelecttxtStudDoj");
           var txtStudClass = document.getElementById("txtStudClass");
           var txtStudSec = document.getElementById("txtStudSec");
           console.log(txtStudDoj.innerText);
           var expEmail = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
           var expPhone = /^[0-9]+$/;
           var expAddress = /^[a-zA-Z0-9 \-\,\:]+$/;

           if (txtStudRegNo.value.trim() === "") {
               alert("Student Registration Number should not be blank!");
               txtStudRegNo.focus();
               return false;
           }

           if (txtStudName.value.trim() === "") {
               alert("Student Name should not be blank!");
               txtStudName.focus();
               return false;
           }

           if (txtStudFName.value.trim() === "") {
               alert("Student Father Name should not be blank!");
               txtStudFName.focus();
               return false;
           }

           if (txtStudAdd.value.trim() === "") {
               alert("Student Address should not be blank!");
               txtStudAdd.focus();
               return false;
           }

           if (!txtStudAdd.value.match(expAddress)) {
               alert("Student Address is invalid!");
               txtStudAdd.focus();
               return false;
           }

           if (!txtStudPhone.value.match(expPhone)) {
               alert("Student Phone should contain only digits!");
               txtStudPhone.focus();
               return false;
           }

           if (!txtStudEmail.value.match(expEmail)) {
               alert("Student Email is invalid!");
               txtStudEmail.focus();
               return false;
           }

           if (txtStudAge.value.trim() === "" || isNaN(txtStudAge.value)) {
               alert("Student Age should be a valid number!");
               txtStudAge.focus();
               return false;
           }

           if (txtStudDoj.innerText.trim() === "") {
               alert("Please select Date of Joining!");
               SelecttxtStudDoj.focus();
               return false;
           }

           if (txtStudClass.value === "Select One") {
               alert("Please select Student Class!");
               txtStudClass.focus();
               return false;
           }

           if (txtStudSec.value === "Select One") {
               alert("Please select Student Section!");
               txtStudSec.focus();
               return false;
           }


           return true;
       }
   </script>


</body>
</html>
