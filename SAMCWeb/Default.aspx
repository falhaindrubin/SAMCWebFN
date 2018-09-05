<%@ Page Title="SAMC Animals Centre" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" MaintainScrollPositionOnPostback="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--<script src="Scripts/jquery-1.10.2/jquery-1.10.2.js" type="text/javascript"></script>--%>
    <%--<script src="Scripts/bootstrap.js" type="text/javascript"></script>--%>

    <script src="Scripts/jquery-1.12.4/jquery-1.12.4.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-1.12.1/jquery-ui.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-timepicker-addon/jquery-ui-timepicker-addon.js" type="text/javascript"></script>

    <%--PLEASE PUT BOOTSTRAP JS TAG AFTER JQUERY TAG--%>
    <script src="Scripts/bootstrap-3.3.7-dist/bootstrap.js" type="text/javascript"></script>

    <link href="Scripts/jquery-ui-1.12.1/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="Scripts/jquery-ui-timepicker-addon/jquery-ui-timepicker-addon.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        $(document).ready(function () {
            $(".carousel").carousel({
                interval: 3000
            })
        });
    </script>

    <%--<div class="jumbotron">

        <div id="myCarousel" class="carousel slide" data-ride="carousel">
            <!-- Indicators -->
            <ol class="carousel-indicators">
                <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                <li data-target="#myCarousel" data-slide-to="1"></li>
                <li data-target="#myCarousel" data-slide-to="2"></li>
            </ol>

            <!-- Wrapper for slides -->
            <div class="carousel-inner">
                <div class="item active">
                    <img src="img/homephoto1.jpg" alt="Domestic Short Hair">
                </div>
                <div class="item">
                    <img src="img/homephoto2.jpg" alt="Mainecoon">
                </div>
                <div class="item">
                    <img src="img/homephoto3.jpg" alt="Shiba Inu">
                </div>
            </div>

            <!-- Left and right controls -->
            <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>

        </div>

        <h1>SAMC Animal Centre</h1>
        <p class="lead">SAMC Animal Center is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.. and slideshow goes here..</p>
        <p><a href="http: //www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>--%>

    <div class="row">
        <div id="myCarousel" class="carousel slide" data-ride="carousel">
            <!-- Indicators -->
            <ol class="carousel-indicators">
                <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                <li data-target="#myCarousel" data-slide-to="1"></li>
                <li data-target="#myCarousel" data-slide-to="2"></li>
            </ol>

            <!-- Wrapper for slides -->
            <div class="carousel-inner">
                <div class="item active">
                    <img src="img/homephoto1.jpg" alt="Domestic Short Hair">
                </div>
                <div class="item">
                    <img src="img/homephoto2.jpg" alt="Mainecoon">
                </div>
                <div class="item">
                    <img src="img/homephoto3.jpg" alt="Shiba Inu">
                </div>
            </div>

            <!-- Left and right controls -->
            <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">            
            <div class="grid-frame-label">
                <h3>Our Story</h3>
            </div>
            <a href="About.aspx">
                <div class="grid-parent">
                    <div class="grid-child-1"></div>
                </div>
                <%--<div class="grid-photo-frame-1"></div>--%>
                <%--<div class="col-content1">
                    <p>
                        ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
                    A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.                       
                    </p>
                    <p>
                        <a class="btn btn-default" href="About.aspx">More.. &raquo;</a>
                    </p>
                </div>--%>
            </a>
        </div>
        <div class="col-md-4">
            <div class="grid-frame-label">
                <h3>Services</h3>
            </div>
            <a href="Services.aspx">
                <div class="grid-parent">
                    <div class="grid-child-2"></div>
                </div>
                <%--<div class="col-content2">
                <p>
                    ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
                    A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.                   
                </p>
                <p>
                    <a class="btn btn-default" href="Services.aspx">More.. &raquo;</a>
                </p>
            </div>--%>
            </a>
        </div>
        <div class="col-md-4">
            <div class="grid-frame-label">
                <h3>Appointment</h3>
            </div>
            <a href="Appointment.aspx">
                <div class="grid-parent">
                    <div class="grid-child-3"></div>
                </div>
                <%--<div class="col-content3">
                    <p>
                        ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
                   A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.  
                    </p>
                    <p>
                        <a class="btn btn-default" href="Appointment.aspx">More.. &raquo;</a>
                    </p>
                </div>--%>
            </a>
        </div>
    </div>
    <div class="row-divider"></div>
    <div class="row">
        <div class="col-md-4">
            <div class="grid-frame-label">
                <h3>Contact</h3>
            </div>
            <a href="Contact.aspx">
                <div class="grid-parent">
                    <div class="grid-child-4"></div>
                </div>
                <%--<div class="col-content4">                
                <p>
                    ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
                    A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
                </p>
                <p>
                    <a class="btn btn-default" href="Gallery.aspx">More.. &raquo;</a>
                </p>
            </div>--%>
            </a>
        </div>
        <div class="col-md-4">
            <div class="grid-frame-label">
                <h3>Gallery</h3>
            </div>
            <a href="Gallery.aspx">
                <div class="grid-parent">
                    <div class="grid-child-5"></div>
                </div>
                <%--<div class="col-content4">
                    <p>
                        ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
                    A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
                    </p>
                    <p>
                        <a class="btn btn-default" href="Gallery.aspx">More.. &raquo;</a>
                    </p>
                </div>--%>
            </a>
        </div>
        <div class="col-md-4">
            <div class="grid-frame-label">
                <h3>FAQ</h3>
            </div>
            <a href="FAQ.aspx">
                 <div class="grid-parent">
                    <div class="grid-child-6"></div>
                </div>
                <%--<div class="col-content4">
                    <p>
                        ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
                    A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
                    </p>
                    <p>
                        <a class="btn btn-default" href="Gallery.aspx">More.. &raquo;</a>
                    </p>
                </div>--%>
            </a>
        </div>
    </div>

</asp:Content>
