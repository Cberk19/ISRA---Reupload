<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="General_404.aspx.cs" Inherits="ISRA.General_404" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ISRA | 503 Error</title>
    <link href="../styles/nav.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@400;700&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="../styles/global.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark">
            <div class="container-fluid">
                <span class="navbar-brand" >
                    <a id="aLogo" runat="server">
                        <img src="../images/isra_logo.png" alt="ISRA Logo" width="75"/>
                    </a>
                </span>
                <div class="d-flex">
                    <ul class="navbar-nav me-4 mb-2 mb-lg-0" runat="server" id="ulAdvisorLinks">
                        <li class="nav-item">
                            <a class="nav-link" href="Advisor_Admin.aspx">Admin</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" aria-current="page" href="Advisor_Search.aspx">View Requests</a>
                        </li>
                    </ul>
                    <ul class="navbar-nav me-4 mb-2 mb-lg-0" runat="server" id="ulStudentLinks">
                        <li class="nav-item">
                            <a class="nav-link" aria-current="page" href="Student_RequestForm.aspx">New Request</a>
                          </li>
                        <li class="nav-item">
                          <a class="nav-link" aria-current="page" href="Student_Search.aspx">View Requests</a>
                        </li>
                     </ul>
                    <ul class="navbar-nav me-4 mb-2 mb-lg-0" runat="server" id="ulFacultyLinks">
                        <li class="nav-item">
                            <a class="nav-link" aria-current="page" href="FacultyMember_Search.aspx">View Requests</a>
                        </li>
                    </ul>
                    <div class="d-flex">
                        <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="btn btn-outline-light"/>
                    </div>
                </div>
            </div>
        </nav>
        <div class="d-flex justify-content-center align-items-center" style="height: 90vh;">
            <div class="text-center">
                <div class="d-flex justify-content-center align-items-center">
                    <h1 class="display-1 mt-3">503</h1>
                    <img src="../images/sad.png" alt="Sad face" class="ms-3" width="75" height="75"/>
                </div>
                <h3>You don't have access to this page</h3>
            </div>
        </div>
    </form>
</body>
</html>
