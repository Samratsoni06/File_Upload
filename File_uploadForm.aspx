<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="File_uploadForm.aspx.cs" Inherits="File_Upload.File_uploadForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <hr />
    <div class="row">
        <div class="row">
            <div class="col-md-12">
                <div class="col-md-4">
                    <asp:Label ID="Msg" runat="server"></asp:Label>
                    <label>Upload</label>
                    <asp:FileUpload runat="server" ID="fileupload" CssClass="form-control" />
                </div>
                <div class="col-md-4">
                    <asp:Button runat="server" Text="Upload" ID="btnupload" OnClick="btnupload_Click" CssClass="btn btn-primary" />
                </div>

            </div>
        </div>
    </div>

    <hr />
    <div class="col-md-4">
        <asp:TextBox runat="server" ID="txtimgid" CssClass="form-control"></asp:TextBox>
        <asp:Button runat="server" Text="ShowImg" ID="btnshow" OnClick="btnshow_Click" CssClass="btn btn-primary" />
    </div>

    <hr />
    <div class="col-md-4">
        <asp:Image ID="img" runat="server" Width="200px" Height="200px" />
    </div>

</asp:Content>
