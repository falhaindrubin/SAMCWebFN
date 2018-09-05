<%@ Page Title="Services" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Services.aspx.vb" Inherits="Services" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3><%: Title %>.</h3>    
   <%-- <h3>Your application description page.</h3>
    <p>Use this area to provide service information.</p>--%>

    <div>
        <p>
            We are a modern fully equipped veterinary clinic.
            Our services are as listed below:  
        </p>
        <ul>
            <li>Medical Consultation & Treatment</li>
            <li>Preventive Health Care</li>
            <li>Traumatic Injury & Emergency</li>
            <li>Soft Tissue Surgery</li>
            <li>Orthopedic Surgery</li>
            <li>Neuro Surgery</li>
            <li>Opthalmology Surgery</li>
            <li>Dental Care & Dental Surgery</li>
            <li>Diagnostic Imaging (Digital X-Ray, Color Doppler Ultrasound)</li>
            <li>Hospitalization & Critical Care</li>
            <li>Cardiology</li>
            <li>Oncology</li>
            <li>Dietary Management</li>
            <li>House Call & Home Delivery</li>
        </ul>
    </div>
</asp:Content>
