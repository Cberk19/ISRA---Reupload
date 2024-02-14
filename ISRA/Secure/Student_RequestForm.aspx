<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student_RequestForm.aspx.cs" Inherits="ISRA.Student_RequestForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ISRA | New Request</title>
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
                <a href="Student_Search.aspx">
                    <img src="../images/isra_logo.png" alt="ISRA Logo" width="75"/>
                </a>
            </span>
            <div class="d-flex">
              <ul class="navbar-nav me-4 mb-2 mb-lg-0">
                  <li class="nav-item">
                    <a class="nav-link active" aria-current="page" href="Student_RequestForm.aspx">New Request</a>
                  </li>
                <li class="nav-item">
                  <a class="nav-link" aria-current="page" href="Student_Search.aspx">View Requests</a>
                </li>
              </ul>
              <div class="d-flex">
                  <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="btn btn-outline-light"/>
              </div>
            </div>
          </div>
        </nav>
        <div class="container my-5 py-2" style="width: 1000px; padding-top: 75px !important;">
            <div class="my-4">
                <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="Go Back" CssClass="btn btn-outline-danger"/>
            </div>
            <h4 class="mb-3 pt-3">Registration Form</h4>
            <div class="card p-4">
                <asp:Label ID="lblAlert" runat="server"></asp:Label>
                <div class="d-flex justify-content-between">
                    <div id="actualForm" class="w-50" style="padding-right: 2rem;">
                        <!--Student Info-->
                        <div id="studentInfo" class="mb-5">
                        <div class="mb-5">
                        <p class="fw-bold mb-2">Student Info</p>
                        <ul class="list-group">
                          <li class="list-group-item d-flex justify-content-between bg-light"><span>TUID: </span><span class="text-secondary" id="txtTUID" runat="server"></span></li>
                          <li class="list-group-item d-flex justify-content-between bg-light"><span>Full Name: </span><span class="text-secondary" id="txtName" runat="server"></span></li>
                          <li class="list-group-item d-flex justify-content-between bg-light"><span>Email: </span><span class="text-secondary" id="txtEmail" runat="server"></span></li>
                          <li class="list-group-item d-flex justify-content-between bg-light"><span>Major: </span><span class="text-secondary" id="txtMajor" runat="server"></span></li>
                        </ul>
                    </div>
                        </div>
                        <!--Faculty Info-->
                        <div id="facultyInfo" class="mb-5">
                            <!--IS-->
                             <div id="ISFacultyInfo">
                                <p class="fw-bold mb-2">Faculty Info*</p>
                                <div class="form-group mb-1">
                                    <label>Supervising Instructor</label>
                                    <asp:TextBox ID="txtGradeInstructor" runat="server" placeholder="Enter Supervising Instructor's Email" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div id="profApproval" runat="server" class="mt-5">
                                    <div class="form-group mt-4 mb-1">
                                        <label class="fw-bold mb-1">Supervising Instructor's Approval Email Screenshot*</label>
                                        <asp:FileUpload ID="fuApproval" runat="server" CssClass="d-block pointer" AllowMultiple="false"/>
                                    </div>
                                    <p>
                                        <small class="text-secondary">
                                            Approval by email is allowed, as long as all information is filled out – including the <strong>Course Plan.</strong>
                                        </small>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <!--Course Info-->
                        <div id="courseInfo" class="mb-5">
                            <p class="fw-bold mb-2">Course Info*</p>
                            <div class="d-flex mb-2">
                                <div class="form-group w-50" style="padding-right: 0.5rem;">
                                    <label>Course Number</label>
                                    <asp:DropDownList ID="ddlCourseNumber" runat="server" CssClass="d-block form-select pointer">
                                        <asp:ListItem>CIS 2082</asp:ListItem>
                                        <asp:ListItem>CIS 3191</asp:ListItem>
                                        <asp:ListItem>CIS 4083</asp:ListItem>
                                        <asp:ListItem>CIS 4282</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group w-50" style="padding-left: 0.5rem;">
                                    <label>Credit Hour</label>
                                    <asp:DropDownList ID="ddlCredits" runat="server" CssClass="d-block form-select pointer">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="d-flex">
                                <div class="form-group w-50" style="padding-right: 0.5rem;">
                                    <label>Semester</label>
                                    <asp:DropDownList ID="ddlSemester" runat="server" CssClass="d-block form-select pointer">
                                        <asp:ListItem>Spring</asp:ListItem>
                                        <asp:ListItem>Summer 1</asp:ListItem>
                                        <asp:ListItem>Summer 2</asp:ListItem>
                                        <asp:ListItem>Fall</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group w-50" style="padding-left: 0.5rem;">
                                    <label>Semester Year</label>
                                    <asp:DropDownList ID="ddlYear" runat="server" CssClass="d-block form-select pointer">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                         <!--Course Plan-->
                        <div id="coursePlan" class="mb-5">
                            <p class="fw-bold">Course Plan*</p>
                            <div class="form-group">
                                <asp:FileUpload ID="fuCoursePlan" runat="server" CssClass="d-block mb-2" AllowMultiple="false"/>
                                <p class="my-2">
                                    <small class="text-secondary d-block mb-1">
                                        Submit this form (with course plan filled out) and it will be sent to the CIS Faculty Advisor
                                        who will verify that all requirements have been met, approve it, file it, 
                                        and register the student for the course.
                                    </small>
                                </p>
                            </div>
                        </div>
                        <!--Extra Note-->
                        <div id="divExtraNote" class="mb-5">
                            <p class="fw-bold mb-2">Extra Note (Optional)</p>
                            <div class="form-group">
                                <textarea id="taExtraNote" cols="20" rows="5" class="form-control d-block" placeholder="Add any additional information you would like to include." runat="server"></textarea>
                            </div>
                        </div>
                        <!--Student Signature-->
                        <div id="signature">
                            <p class="fw-bold mb-2">Student Signature*</p>
                            <div class="form-group">
                                <label>Full Name</label>
                                <asp:TextBox ID="txtSignature" runat="server" placeholder="Print Full First and Last Name" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <!--Submit button-->
                        <div class="d-grid gap-2 my-4">
                            <asp:Button ID="btnSubmit" runat="server" OnClick="btnComplete_Click" Text="Submit" CssClass="btn btn-danger"/>
                        </div>
                    </div>
                    <!--Requisite Info-->
                    <div id="reqInfo" class="w-50" style="padding-left: 2rem;">
                        <div id="preReq" runat="server">
                            <p class="fw-bold mb-2">Pre-requisite Info <i class="bi-info-circle-fill text-info"></i></p>
                            <div id="indStudyOne" class="card p-3">
                                <p class="fw-bold">CIS 2082 (Independent Study 1)</p>
                                <p>GPA Requirement: <small class="text-secondary">3.0</small></p>
                                <p>Pre-requisites: <small class="text-secondary">CIS 2168</small></p>
                                <p>Note: <small class="text-secondary">No CIS major credit, but counted in CIS major GPA</small></p>
                            </div>
                            <div id="indResearchTwo" class="card p-3">
                                <p class="fw-bold">CIS 3191 (Independent Research 2)</p>
                                <p>GPA Requirement: <small class="text-secondary">3.0</small></p>
                                <p>Pre-requisites: <small class="text-secondary">CIS 2168 & (3207 or 3223 or 3309)</small></p>
                                <p>Note: <small class="text-secondary">No CIS major credit, but counted in CIS major GPA</small></p>
                            </div>
                            <div id="directedReadingStudy" class="card p-3">
                                <p class="fw-bold">CIS 4083 (Directed Reading / Study)</p>
                                <p>GPA Requirement: <small class="text-secondary">3.0</small></p>
                                <p>Pre-requisites: <small class="text-secondary">CIS 2168 & (3207 or 3223 or 3309)</small></p>
                                <p>Note: <small class="text-secondary">A course (not research). No CIS major credit, but
                                    counted in CIS major GPA. </small></p>
                            </div>
                            <div id="indStudy" class="card p-3">
                                <p class="fw-bold">CIS 4282 (Independent Study)</p>
                                <p>GPA Requirement: <small class="text-secondary">3.0</small></p>
                                <p>Pre-requisites: <small class="text-secondary">CIS 2168 & (3207 or 3223 or 3309)</small></p>
                                <p>Note: <small class="text-secondary">A maximum of 8 credits of CIS 4282 and/or Coop (CIS
                                    3281 or 3381) <strong>may be counted towards your CIS major</strong> (upper level elective). Counted in CIS major GPA.</small>
                                </p>
                            </div>
                        </div>
                        <div id="eligibility" runat="server" visible="false">
                            <p class="fw-bold mb-2">Eligibility Info <i class="bi-info-circle-fill text-info"></i></p>
                            <div class="reqObj card p-3">
                                <p >Requirement 1:</p>
                                <small class="text-secondary">
                                    Current CST undergraduate Student
                                </small>
                            </div>
                            <div class="reqObj card p-3">
                                <p>Requirement 2:</p>
                                <small class="text-secondary">
                                    Overall GPA of 2.75 & CST GPA of 2.75 in all CST
                                    classes (retakes are included in CST GPA calculation.)
                                </small>
                            </div>
                            <div class="reqObj card p-3">
                                <p>Requirement 3:</p>
                                <small class="text-secondary">
                                    Successfully completed the appropriate level of mathematics for your 
                                    major (For a majority of majors that is MATH 1041/1941 Calculus I)
                                </small>
                            </div>
                            <div class="reqObj card p-3">
                                <p>Requirement 4:</p>
                                <small class="text-secondary">
                                    Completed two semesters in CST or if a transfer student, must have 
                                    successfully transferred 20 credits in science or math
                                </small>
                            </div>
                            <div class="reqObj card p-3">
                                <p>Requirement 5:</p>
                                <small class="text-secondary">
                                    Students can only participate in URP for a total of two semesters,
                                    only one of which can be summer. Students cannot do two summers of 
                                    URP
                                </small>
                            </div>
                        </div>
                        <p class="p-3">
                            <small class="text-secondary">
                                Under exceptional circumstances, a student and instructor may ask the Director of CIS Undergraduate Programs
                                (Gene Kwatny, <a href="mailto:kwatny@temple.edu" class="text-danger">kwatny@temple.edu</a>) for a relaxation of these rules (must be obtained prior to registration).
                            </small>
                        </p>
                    </div>
                </div>
            </div>
        </div>            
    </form>
</body>
</html>
