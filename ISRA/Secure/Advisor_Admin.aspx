<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Advisor_Admin.aspx.cs" Inherits="ISRA.Advisor_Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ISRA | Admin</title>
    <link href="../styles/nav.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@400;700&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="../styles/global.css"/>
    <style>
        .chkClass input {
            cursor: pointer;
            width: 20px;
            height: 20px;
        }
        .disabled-gray {
            cursor: not-allowed !important;
            background: #D3D3D3 !important;
            color: gray !important;
        }
        .sidebar {
            background: #F7F7F7;
            border-right: 1px solid #CED4DA;
            width: 300px;
            left: 0px;
        }

        .add-user {
            
            background: #D9D9D9;
        }

        #backgroundDim{
            position:fixed;
            height:100%;
            width:100%;
            top:0rem;
            left:0rem;
            background-color:black;
            opacity:50%;
        }

        #adminPanel{
            position:fixed;
            padding:2rem;
            margin:auto;
            top:50%;
            left:50%;
            width: 500px;
            transform: translate(-50%, -50%);
            background-color:white;
            border-radius:.5rem;
        }

        input::-webkit-outer-spin-button,
        input::-webkit-inner-spin-button {
            -webkit-appearance: none;
            margin: 0;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark">
          <div class="container-fluid">
            <span class="navbar-brand" >
                <a href="Advisor_Search.aspx">
                    <img src="../images/isra_logo.png" alt="ISRA Logo" width="75"/>
                </a>
            </span>
            <div class="d-flex">
              <ul class="navbar-nav me-4 mb-2 mb-lg-0">
                <li class="nav-item">
                    <a class="nav-link active" href="Advisor_Admin.aspx">Admin</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" aria-current="page" href="Advisor_Search.aspx">View Requests</a>
                </li>
              </ul>
              <div class="d-flex">
                <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="btn btn-outline-light"/>
              </div>
            </div>
          </div>
        </nav>
        <div class="d-flex">
            <div class="sidebar vh-100 position-relative top-0 pt-4">
                <asp:Button ID="btnAddUsers" runat="server" Text="Add Users" CssClass="add-user px-4 border-0 text-start fw-bold py-3 w-100" OnClick="btnAddUsers_Click"/>
                <asp:Button ID="btnEmailTemplate" runat="server" Text="Email Template" CssClass="px-4 border-0 text-start fw-bold py-3 w-100" OnClick="btnEmailTemplate_Click"/>
            </div>
            <div class="w-100 container my-5">
                <div id="addUsersView" runat="server" visible="true">
                    <div class="mb-5">
                        <div class="d-flex justify-content-between align-items-center mb-2">
                            <h2>Admins</h2>
                            <asp:Button ID="btnAddAdmin" runat="server" Text="Add Admin" CssClass="btn btn-danger" OnClick="btnAddAdmin_Click" />
                        </div>
                        <asp:Label ID="lblAdminAlert" runat="server"></asp:Label>
                        <asp:GridView ID="gvAdmins" runat="server" CssClass="table table-striped table-hover" AutoGenerateColumns="False" onrowcommand="gvAdmins_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="Email" HeaderText="Email" />
                                <asp:BoundField DataField="First" HeaderText="First Name" />
                                <asp:BoundField DataField="Last" HeaderText="Last Name" />
                                <asp:TemplateField HeaderText="Receive Emails">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkReceiveEmails" runat="server" Checked='<%#Convert.ToBoolean(Eval("Receive_Emails")) %>' CssClass="chkClass"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="false">
                                    <ItemTemplate>
                                        <div class="d-flex justify-content-center">
                                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-outline-danger" CommandName="Save"/>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                    </div>
                </div>
                <div id="emailTemplateView" runat="server" visible="false">
                    <div class="d-flex mt-5 mb-3">
                        <%--titles split--%>
                        <h2 class="w-50 me-4">Edit the Email Template</h2>
                        <h2 class="w-50 ms-4">Email Preview</h2>
                    </div>
                    <div>
                        <%--dropdown--%>
                        <label class="fw-bold">Email Type</label>
                        <asp:DropDownList ID="ddStatus" runat="server" CssClass="form-select pointer" style="max-width:25%;" OnSelectedIndexChanged="changeValues" AutoPostBack="true">
                            <asp:ListItem>Request Submitted (sent to Registrar and Instructors)</asp:ListItem>
                            <asp:ListItem>Request Submitted (sent to Student)</asp:ListItem>
                            <asp:ListItem>Status Changed (sent to all)</asp:ListItem>
                        </asp:DropDownList>
                        <p class="text-secondary mt-2" id="emailTypeExplanation1" runat="server" visible="true" style="max-width:25%;">
                            This email will be sent to <span>Registrars and Supervising Instructors</span> when a student <span>first submits a request</span>.
                        </p>
                        <p class="text-secondary mt-2" id="emailTypeExplanation2" runat="server" visible="false" style="max-width:25%;">
                            This email will be sent to the <span>Student</span> when a they <span>first submit a request</span>.
                        </p>
                        <p class="text-secondary mt-2" id="emailTypeExplanation3" runat="server" visible="false" style="max-width:25%;">
                            This email will be sent to the <span>Student and Instructor</span> when a student's request gets changed.
                        </p>
                    </div>
                    <div class="d-flex my-5">
                        <%--form and preview split--%>
                        <div class="w-50 me-4">
                            <asp:Label ID="lblEmailTemplateAlert" runat="server"></asp:Label>
                            <div class="form-group">
                                <label>Subject</label>
                                <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control mb-2" Text="Request Form for" oninput="subjectChange();"></asp:TextBox>
                                <label>Intro</label>
                                <textarea id="taIntro" cols="20" rows="5" class="form-control mb-2" oninput="introChange();" runat="server">
                                </textarea>
                                <label>Additional Info</label>
                                <textarea id="taAdditional" cols="20" rows="5" class="form-control mb-2" oninput="addyChange();" runat="server">
                                </textarea>
                                <label>Ending</label>
                                <textarea id="taEnding" cols="20" rows="5" class="form-control mb-2" oninput="endingChange();" runat="server">
                                </textarea>
                                <label>Who to contact</label>
                                <asp:TextBox ID="txtContact" runat="server" CssClass="form-control mb-2" oninput="contactChange();"></asp:TextBox>
                            </div>
                            <div class="d-flex justify-content-end my-4"> 
                                <asp:Button ID="btnSave" runat="server" Text="Save Template" CssClass="btn btn-danger" OnClick="SaveEmailTemplate_Click"/>
                            </div>
                        </div>
                        <div class="w-50 ms-4">
                            <span class="fw-bold">Subject:</span>
                            <p id="subjectPreview" runat="server" class="mb-3">Request Form for &lt;application&gt; &lt;status&gt;</p>
                            <p>Hi <span class="text-secondary">&lt;receiver name&gt;,</span></p>
                            <p id="introPreview" runat="server"></p>
                            <p id="addyPreview" runat="server" class="mb-3"></p>
                            <p class="mb-3">
                                <span class="d-block fw-bold">Student Info:</span>
                                <span class="d-block">Access net: <span class="text-secondary">&lt;student access net&gt;</span></span>
                                <span class="d-block">TUID: <span class="text-secondary">&lt;student tuid&gt;</span></span>
                                <span class="d-block">Full Name: <span class="text-secondary">&lt;student first and last&gt;</span></span>
                                <span class="d-block">Email: <span class="text-secondary">&lt;student email&gt;</span></span>
                                <span class="d-block">Major: <span class="text-secondary">&lt;student major&gt;</span></span>
                            </p>
                            <p class="mb-3">
                                <span class="d-block fw-bold">Faculty Info:</span>
                                <span class="d-block">Registered by: <span class="text-secondary">&lt;email of registrar&gt;</span></span>
                                <span class="d-block">Grade Instructor: <span class="text-secondary">&lt;supervising instructor email&gt;</span></span>
                            </p>
                            <p class="mb-3">
                                <span class="d-block fw-bold">Course Info:</span>
                                <span class="d-block">Course Requested: <span class="text-secondary">&lt;course number&gt;</span></span>
                                <span class="d-block">Credits: <span class="text-secondary">&lt;number of credits&gt;</span></span>
                                <span class="d-block">CRN: <span class="text-secondary">&lt;crn&gt;</span></span>
                                <span class="d-block">Section: <span class="text-secondary">&lt;section number&gt;</span></span>
                                <span class="d-block">Semester: <span class="text-secondary">&lt;semester and year&gt;</span></span>
                            </p>
                            <p>Please contact <span class="fw-bold d-inline-block" id="contactPreview" runat="server"></span> if you have any questions</p>
                            <br />
                            <p>
                                <span class="d-block" id="endingPreview" runat="server"></span>
                                <span class="d-block">Dominic Letarte</span>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="backgroundDim" runat="server" visible="false" onserverclick="backgroundDim_Click"></div>
        <div class="admin-panel form-group" id="adminPanel" runat="server" visible="false">
            <div class="d-flex justify-content-end">
                <button type="button" class="btn-close" aria-label="Close" runat="server" onserverclick="btnModalClose_Click"></button>
            </div>
            <h5 class="mb-4">Add an admin</h5>
            <label for="tuid">TUID:</label>
            <br />
            <input type="number" min="0" max="1000000000" id="tuid" name="tuid" class="form-control" placeholder="Enter TUID" runat="server"/><br />

            <label for="email">Email:</label>
            <br />
            <input type="text" id="email" name="email" class="form-control" placeholder="Enter Email" runat="server"/><br />
            <label for="fname">First Name:</label>
            <br />
            <input type="text" id="fname" name="fname" class="form-control" placeholder="Enter First Name" runat="server"/><br />
            <label for="lname">Last Name:</label><br />
            <input type="text" id="lname" name="lname" class="form-control" placeholder="Enter Last Name" runat="server"/><br />
            <div class="d-flex justify-content-end">
                <asp:Button ID="adminAdd" CssClass="btn btn-danger" runat="server" Text="Add" OnClick="adminAdd_Click"/>
            </div>
        </div>
    </form>

    <script>
        function subjectChange() {
            document.getElementById('subjectPreview').innerHTML = document.getElementById('txtSubject').value;
        }

        function introChange() {
            document.getElementById('introPreview').innerHTML = document.getElementById('taIntro').value;
        }

        function addyChange() {
            document.getElementById('addyPreview').innerHTML = document.getElementById('taAdditional').value;
        }

        function endingChange() {
            document.getElementById('endingPreview').innerHTML = document.getElementById('taEnding').value;
        }

        function contactChange() {
            document.getElementById('contactPreview').innerHTML = document.getElementById('txtContact').value;
        }
    </script>
</body>
</html>