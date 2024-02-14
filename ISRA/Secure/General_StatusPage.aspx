<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="General_StatusPage.aspx.cs" Inherits="ISRA.General_StatusPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ISRA | Status</title>
    <link href="../styles/nav.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@400;700&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="../styles/global.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark position-fixed w-100 top-0" style="z-index: 1;">
          <div class="container-fluid">
            <span class="navbar-brand" >
                <a id="aLogo" runat="server">
                    <img src="../images/isra_logo.png" alt="ISRA Logo" width="75"/>
                </a>
            </span>
              <div class="d-flex">
              <ul class="navbar-nav me-4 mb-2 mb-lg-0">
                  <li class="nav-item" runat="server" id="viewRequestsLinkFaculty">
                      <a class="nav-link active" aria-current="page" href="FacultyMember_Search.aspx">View Requests</a>
                    </li>
                  <li class="nav-item" runat="server" id="newRequestLinkStudent">
                    <a class="nav-link" aria-current="page" href="Student_RequestForm.aspx">New Request</a>
                  </li>
                <li class="nav-item" runat="server" id="viewRequestsLinkStudent">
                  <a class="nav-link active" aria-current="page" href="Student_Search.aspx">View Requests</a>
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
                <a href="#" runat="server" id="linkReturn" class="btn btn-outline-danger">Go Back</a>
            </div>
            <div class="d-flex">
                <!--Request Info-->
                <div class="w-50" style="padding-right: 2rem;">
                    <div class="d-flex align-items-center">
                        <h4 class="mb-3 pt-3" style="padding-right: 0.5rem;">Registration Form (#<span id="spanIsraID" runat="server"></span>)</h4>
                        <span class="badge bg-dark">Independent Study</span>
                    </div>
                    <p id="lblDateSubmitted" class="text-secondary" runat="server">Submitted on: </p>
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
                        </ul>
                    </div>
                    <div class="my-5">
                        <p class="fw-bold mb-2">Course Info</p>
                        <ul class="list-group">
                          <li class="list-group-item d-flex justify-content-between bg-light"><span>Course Requested: </span><span class="text-secondary" id="Course_Number" runat="server"></span></li>
                          <li class="list-group-item d-flex justify-content-between bg-light"><span>Credits: </span><span class="text-secondary" id="Credits" runat="server"></span></li>
                          <li class="list-group-item d-flex justify-content-between bg-light"><span>CRN: </span><span class="text-secondary" id="CRN" runat="server"></span></li>
                          <li class="list-group-item d-flex justify-content-between bg-light"><span>Section: </span><span class="text-secondary" id="Section" runat="server"></span></li>
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
                    <div class="d-flex align-items-center mb-5">
                        <div id="divSubmittedCircle" runat="server" class="bg-danger p-1 rounded-circle d-flex justify-content-center" style="width: 40px; height: 40px;"><i class="bi-file-earmark-text text-white"></i></div>
                        <div id="divSubmittedLine" runat="server" style="height: 7px; width: 25%; margin-right: 1rem; margin-left: 1rem;" class="bg-danger">
                            <small id="smallSubmittedTxt" runat="server" class="text-center d-block m-2">Submitted</small>
                        </div>
                        <div id="divPendingCircle" runat="server" class="bg-danger p-1 rounded-circle d-flex justify-content-center align-items-center" style="width: 90px; height: 90px;"><i id="iHourglassIcon" runat="server" class="text-white bi-hourglass-bottom mb-1" style="font-size: 24px;"></i></div>
                        <div id="divApprovedLine" runat="server" style="height: 7px; width: 25%; margin-right: 1rem; margin-left: 1rem; background: #e8a9af;">
                            <small id="smallApprovedTxt" runat="server" class="text-center d-block mt-2 text-secondary">Approved</small>
                        </div>
                        <div id="divApprovedCircle" runat="server" class="p-1 rounded-circle d-flex justify-content-center align-items-center" style="width: 40px; height: 40px; background: #e8a9af;"><i id="iCheckIcon" runat="server" class="bi-check text-white"></i></div>
                    </div>
                    <div class="d-flex align-items-center mb-2">
                        <p class="fw-bold" style="padding-right: 0.75rem;">Status:</p><span class="text-black-50 fw-bold" id="Status" runat="server"></span>
                    </div>
                    <small class="text-secondary" id="Status_Reason" runat="server">
                        
                    </small>
                </div>
            </div>
        </div>
    </form>
</body>
</html>