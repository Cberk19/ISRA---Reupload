<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="General_LandingPage.aspx.cs" Inherits="ISRA.General_LandingPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ISRA</title>
    <style>
        .bg-skyline {
            background: url("https://images.unsplash.com/photo-1553877522-43269d4ea984?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1740&q=80");
            background-repeat: no-repeat;
            background-size: cover;
        }
        .tint {
            background: rgba(0, 0, 0, 0.6);
            position: absolute;
            top: 0;
            bottom: 0;
            left: 0;
            right: 0;
        }
    </style>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@400;700&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="styles/global.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="bg-skyline vh-100 position-relative d-flex justify-content-center align-items-center">
            <div class="tint" style="padding: 5rem 3rem; width: 700px;">
                <div class="position-relative z-1 text-white jumbotron">
                    <h1 class="display-4">ISRA</h1>
                    <p class="lead">Independent Study Registration Application</p>
                    <hr class="my-4">
                    <p>The CIS Department offers Independent Study, Independent Research and Directed Reading/Study courses, which allow motivated students to work on projects under the supervision of a faculty advisor while receiving academic credit.</p>
                    <p class="lead pt-3">
                        <asp:Button ID="btnLoginTemple" runat="server" Text="Go to dashboard" OnClick="btnLoginTemple_Click" CssClass="btn btn-danger btn-lg" OnClientClick="target='_blank';"/>
                    </p>
                </div>
            </div>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js" integrity="sha384-IQsoLXl5PILFhosVNubq5LC7Qb9DXgDA9i+tQ8Zj3iwWAwPtgFTxbJ8NT4GN1R8p" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.min.js" integrity="sha384-cVKIPhGWiC2Al4u+LWgxfKTRIcfu0JTxR+EQDz/bgldoEyl4H0zUF0QKbrJ0EcQF" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</body>
</html>
