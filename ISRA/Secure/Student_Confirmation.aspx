<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student_Confirmation.aspx.cs" Inherits="ISRA.Student_Confirmation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ISRA | Confirmation</title>
    <link href="../styles/nav.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
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
                <a href="Student_Search.aspx">
                    <img src="../images/isra_logo.png" alt="ISRA Logo" width="75"/>
                </a>
            </span>
            <div class="d-flex">
              <ul class="navbar-nav me-4 mb-2 mb-lg-0">
                  <li class="nav-item">
                    <a class="nav-link" aria-current="page" href="Student_RequestForm.aspx">New Request</a>
                  </li>
                <li class="nav-item">
                  <a class="nav-link active" aria-current="page" href="Student_Search.aspx">View Requests</a>
                </li>
              </ul>
              <div class="d-flex">
                  <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="btn btn-outline-light"/>
              </div>
            </div>
          </div>
        </nav>
        <div class="d-flex justify-content-center align-items-center vh-100">
            <div class="text-center w-25">
                <img src="../images/checked.png" width="125"/>
                <h1 class="display-4 my-3">Thank You</h1>
                <p class="text-secondary">
                    Your request has been sent and you should receive an email shortly.
                </p>
                <p class="text-secondary">
                    View your requests <a href="Student_Search.aspx" class="text-danger">here</a>
                </p>
            </div>
        </div>
    </form>
</body>
</html>
