<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Advisor_RequestDetails.aspx.cs" Inherits="ISRA.Advisor_RequestDetails" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ISRA | Request Details</title>
    <link href="../styles/nav.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@400;700&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="../styles/global.css"/>
</head>
<body>
    <form id="form2" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark position-fixed w-100 top-0" style="z-index: 1;">
          <div class="container-fluid">
            <span class="navbar-brand" >
                <a href="Advisor_Search.aspx">
                    <img src="../images/isra_logo.png" alt="ISRA Logo" width="75"/>
                </a>
            </span>
            <div class="d-flex">
              <ul class="navbar-nav me-4 mb-2 mb-lg-0">
                <li class="nav-item">
                    <a class="nav-link" href="Advisor_Admin.aspx">Admin</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link active" aria-current="page" href="Advisor_Search.aspx">View Requests</a>
                </li>
              </ul>
              <div class="d-flex">
                <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="btn btn-outline-light"/>
              </div>
            </div>
          </div>
        </nav>
        <div class="container my-5 py-2" style="width: 1000px; padding-top: 75px !important;">
            <div class="mt-4 mb-2">
                <asp:Button ID="btnGoBack" runat="server" Text="Go Back" CssClass="btn btn-outline-danger" OnClick="btnGoBack_Click"/>
            </div>
            <div class="d-flex">
                <!--Request Info-->
                <div class="w-50" style="padding-right: 2rem;">
                    <div class="d-flex align-items-center">
                        <h4 class="mb-3 pt-3" style="padding-right: 0.5rem;">Registration Form (#<span id="spanIsraID" runat="server"></span>)</h4>
                        <span class="badge bg-dark">Independent Study</span>
                    </div>
                    <p class="text-secondary" id="lblDateSubmitted" runat="server">Submitted on: </p>
                    <div class="my-5">
                        <p class="fw-bold mb-2">Student Info</p>
                        <ul class="list-group">
                          <li class="list-group-item d-flex justify-content-between bg-light"><span>TUID: </span><span class="text-secondary" id="TUID" runat="server"></span></li>
                          <li class="list-group-item d-flex justify-content-between bg-light"><span>Full Name: </span><span class="text-secondary" id="Full_Name" runat="server"></span></li>
                          <li class="list-group-item d-flex justify-content-between bg-light"><span>Email: </span><span class="text-secondary" id="Email" runat="server"></span></li>
                          <li class="list-group-item d-flex justify-content-between bg-light"><span>Major: </span><span class="text-secondary" id="Major" runat="server"></span></li>
                        </ul>
                    </div>
                    <div class="my-5">
                        <p class="fw-bold mb-2">Faculty Info</p>
                        <ul class="list-group">
                          <li class="list-group-item d-flex justify-content-between bg-light"><span>Registered by: </span><span class="text-secondary" id="Registered_By" runat="server"></span></li>
                          <li class="list-group-item d-flex justify-content-between bg-light"><span>Supervising Instructor: </span><span class="text-secondary" id="Grade_Instructor" runat="server"></span></li>
                            <li class="list-group-item bg-light">
                                <span>Instructor Approval Screenshot: </span>
                                <div class="p-3">
                                    <asp:Image ID="imgApproval" runat="server" CssClass="w-100" />
                                </div>
                            </li>
                        </ul>
                    </div>
                    <div class="my-5">
                        <p class="fw-bold mb-2">Course Info</p>
                        <ul class="list-group">
                          <li class="list-group-item d-flex justify-content-between bg-light"><span>Course Requested: </span><span class="text-secondary" id="Course_Number" runat="server"></span></li>
                          <li class="list-group-item d-flex justify-content-between bg-light"><span>Credits: </span><span class="text-secondary" id="Credits" runat="server"></span></li>
                          <li class="list-group-item d-flex justify-content-between bg-light"><span>Semester: </span><span class="text-secondary" id="Semester" runat="server"></span></li>
                        </ul>
                    </div>
                    <div class="my-5">
                        <p class="fw-bold">Course Plan</p>
                        <asp:HyperLink ID="linkCoursePlan" runat="server" Text="View PDF" Target="_blank" CssClass="text-danger"></asp:HyperLink>
                        <asp:LinkButton ID="lbCoursePlanDownload" runat="server" OnClick="lbCoursePlanDownload_Click" Visible="false" CssClass="text-danger">Download document</asp:LinkButton>
                    </div>
                    <div class="my-5">
                        <p class="fw-bold mb-2">Extra Note (from Student)</p>
                        <textarea id="taExtraNote" cols="20" rows="5" class="card form-control bg-light" runat="server"></textarea>
                    </div>
                </div>
                <!--Status Info-->
                <div class="w-50" style="padding-left: 2rem;">
                    <asp:Label ID="lblAlert" runat="server"></asp:Label>
                    <div class="form-group mb-4">
                        <p class="fw-bold mb-2">Register Student</p>
                        <label>CRN</label>
                        <asp:TextBox ID="txtCRN" runat="server" CssClass="form-control mb-2" placeholder="Enter CRN"></asp:TextBox>
                        <label>Section</label>
                        <asp:TextBox ID="txtSection" runat="server" CssClass="form-control" placeholder="Enter a section number"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <p class="fw-bold mb-2">Status</p> 
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-select mb-2 pointer">
                            <asp:ListItem Value="DENIED">DENIED</asp:ListItem>
                            <asp:ListItem Value="PENDING">PENDING</asp:ListItem>
                            <asp:ListItem Value="APPROVED">APPROVED</asp:ListItem>
                        </asp:DropDownList>
                        <div class="d-flex flex-column">
                            <label>Reason for status (if necessary)</label>
                            <textarea id="taStatusReason" cols="20" rows="5" placeholder="Include more information why this status was chosen" class="form-control" runat="server"></textarea>
                        </div>
                    </div>
                    <div class="d-grid gap-2 my-4">
                        <asp:Button ID="btnUpdateStatus" runat="server" Text="Update" CssClass="btn btn-danger" OnClick="btnUpdateStatus_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
