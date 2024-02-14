<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student_Search.aspx.cs" Inherits="ISRA.Student_Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ISRA | Search</title>
    <link href="../styles/nav.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@400;700&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="../styles/global.css"/>
    <link rel="stylesheet" href="../styles/search.css"/>
    <style>
        .sidebar {
            background: #F7F7F7;
            border-right: 1px solid #CED4DA;
        }
        .tableRow:hover {
            background: #F7F7F7;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark position-fixed w-100" style="z-index: 1;">
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
        <!--Side Filter-->
        <div class="sidebar position-fixed p-4 border-end bottom-0" style="top: 70px; z-index: 1; width: 277px;">
            <!--Filter-->
            <div id="filter" class="mb-5 pt-3">
                <div class="d-flex justify-content-between">
                    <p class="fw-bold mb-4">Filter by: </p>
                    <asp:LinkButton ID="lbClearFilters" runat="server" CssClass="text-danger" OnClick="lbClearFilters_Click">Clear</asp:LinkButton>
                </div>
                <div class="form-group mb-2">
                    <label>Search</label>
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="ID, Name, Email, etc..."></asp:TextBox>
                </div>
                <div class="form-group mb-2">
                    <label>Course</label>
                    <asp:DropDownList ID="ddlCourse" runat="server" CssClass="form-select pointer">
                        <asp:ListItem>Any</asp:ListItem>
                        <asp:ListItem>CIS 2082</asp:ListItem>
                        <asp:ListItem>CIS 3191</asp:ListItem>
                        <asp:ListItem>CIS 4083</asp:ListItem>
                        <asp:ListItem>CIS 4282</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group mb-2">
                    <label>Semester</label>
                    <asp:DropDownList ID="ddlSemester" runat="server" CssClass="form-select pointer">
                        <asp:ListItem>Any</asp:ListItem>
                        <asp:ListItem>Spring</asp:ListItem>
                        <asp:ListItem>Summer 1</asp:ListItem>
                        <asp:ListItem>Summer 2</asp:ListItem>
                        <asp:ListItem>Fall</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group mb-2">
                    <label>Status</label>
                    <asp:DropDownList ID="ddlAppStatus" runat="server" CssClass="form-select pointer">
                        <asp:ListItem>Any</asp:ListItem>
                        <asp:ListItem>PENDING</asp:ListItem>
                        <asp:ListItem>DENIED</asp:ListItem>
                        <asp:ListItem>APPROVED</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!--Sort-->
            <div class="sort mb-5">
                <div class="d-flex justify-content-between">
                    <p class="fw-bold mb-4">Sort by: </p>
                </div>
                <div class="form-check">
                    <label class="form-check-label pointer">
                        <input id="radAlph" runat="server" class="form-check-input" type="radio" name="sorts" value="alphabetical"/>
                        Alphabetical (name)
                    </label>
                </div>
                <div class="form-check">
                    <label class="pointer">
                        <input id="radNew" runat="server" class="form-check-input" type="radio" name="sorts" value="newest" checked/>
                        Newest to oldest
                    </label>
                </div>
                <div class="form-check">
                    <label class="pointer">
                        <input id="radOld" runat="server" class="form-check-input" type="radio" name="sorts" value="oldest"/>
                        Oldest to newest
                    </label>
                </div>
            </div>
            <asp:Button ID="btnApply" runat="server" Text="Apply" CssClass="btn btn-danger w-100" OnClick="btnApply_Click"/>
        </div>
        <!--Results-->
        <div class="d-flex position-relative" style="top: 70px;">
            <div style="min-width: 277px;"></div>
            <div id="results" class="container my-5">
                <div class="d-flex justify-content-between align-items-center mb-2">
                    <h4>Requests (<span id="spanResultCount" runat="server"></span>)</h4>
                    <a href="Student_RequestForm.aspx" class="btn btn-danger">New Request +</a>
                </div>

                <div class="d-flex" style="margin-bottom: 4rem;">
                    <p class="fw-bold" style="margin-right: 1rem;">Filters:</p>
                    <div id="divCurrentFilters" runat="server"></div>
                </div>
                
                <table class="w-100">
                    <tr class="border-bottom">
                        <th class="fw-normal text-secondary">ID</th>
                        <th class="fw-normal text-secondary">Requester</th>
                        <th class="fw-normal text-secondary">Course</th>
                        <th class="fw-normal text-secondary">Semester</th>
                        <th class="fw-normal text-secondary">Status</th>
                        <th class="fw-normal text-secondary">Date</th>
                    </tr>
                    <asp:Repeater ID="rptRequests" runat="server" OnItemCommand="rpt_ItemCommand" OnItemDataBound="Item_Bound">
                        <ItemTemplate>
                            <tr class="border-bottom tableRow position-relative">
                                <td>
                                    <asp:Label ID="lblIsraId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Isra_Id")%>'></asp:Label>
                                </td>
                                <td class="d-flex align-items-center my-2">
                                    <div id="divInitials" runat="server" style="width: 40px; height: 40px;" class="d-flex justify-content-center align-items-center">
                                        <asp:Label ID="lblStudentInitials" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "GetStudentInitials")%>' CssClass="d-inline-block text-white p-2 w-100 text-center"></asp:Label>
                                    </div>
                                    <div class="ms-2">
                                        <div style="position: relative; top: 2px;">
                                            <asp:Label ID="lblStudentFirst" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Student_First")%>' CssClass="fw-bold"></asp:Label>
                                            <asp:Label ID="lblStudentLast" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Student_Last")%>' CssClass="fw-bold" style="padding-right: 0.5rem;"></asp:Label>
                                        </div>
                                        <small class="text-secondary" style="position: relative; top: -2px;">
                                            <asp:Label ID="lblStudentEmail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Student_Email")%>'></asp:Label>
                                        </small>
                                    </div>
                                </td>
                                <td>
                                    <asp:Label ID="lblCourseNumber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Course_Number")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblSemester" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Semester")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Status")%>' CssClass="fw-bold text-uppercase badge rounded-pill text-bg-secondary bg-secondary" Visible='<%# (Eval("Status").ToString().ToUpper().CompareTo("PENDING") == 0) %>'></asp:Label>
                                    <asp:Label ID="lblStatusDenied" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Status")%>' CssClass="fw-bold text-uppercase badge rounded-pill text-bg-danger bg-danger" Visible='<%# (Eval("Status").ToString().ToUpper().CompareTo("DENIED") == 0) %>'></asp:Label>
                                    <asp:Label ID="lblStatusApproved" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Status")%>' CssClass="fw-bold text-uppercase badge rounded-pill text-bg-success bg-success" Visible='<%# (Eval("Status").ToString().ToUpper().CompareTo("APPROVED") == 0) %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblDateSubmitted" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Date_Submitted").ToString().Split()[0]%>'></asp:Label>
                                </td>
                                <td class="d-flex justify-content-end">
                                    <asp:Button ID="btnView" runat="server" CssClass="rowBtn" CommandArgument='<%# Container.ItemIndex %>' OnCommand="btn_View"/>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
        
    </form>
</body>
</html>