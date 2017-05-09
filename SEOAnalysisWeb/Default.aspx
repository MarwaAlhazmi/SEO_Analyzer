<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SEOAnalysisWeb.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/dataTables.tableTools.min.css" rel="stylesheet" />
    <link href="Content/jquery.dataTables.min.css" rel="stylesheet" />
    <div class="well well-lg">
        <p style="color: black">Enter URL or Text to generate SEO report</p>

        <div class="row control-group">
            <div class="form-group col-xs-12 floating-label-form-group controls floating-label-form-group-with-value">
                <label for="url"></label>
                <input type="url" class="form-control" placeholder="URL Address" id="url" runat="server" data-validation-required-message="Please enter URL." aria-invalid="false">
                <p class="help-block text-danger"></p>
            </div>

            <br />
            <div class="form-group col-xs-12 floating-label-form-group controls floating-label-form-group-with-value">
                <label for="text"></label>
                <input type="text" aria-multiline="true" class="form-control" placeholder="Text" id="text" runat="server" aria-invalid="false">
                <p class="help-block text-danger"></p>
            </div>
        </div>
        <br />
        <div class="pull-left">
            <div class="btn-group" data-toggle="buttons">
                <label class="btn btn-warning" runat="server" id="metabutton">
                    <input type="checkbox" id="ckMeta" runat="server">
                    Calculate Meta tags Occurences
                </label>
                <label class="btn btn-warning" runat="server" id="linkbutton">
                    <input type="checkbox" id="ckExternal" runat="server">
                    Number of External Links
                </label>
            </div>
        </div>
        <div class="pull-right">
            <input type="submit" runat="server" class="btn btn-primary btn-lg" id="btnAnalyze" value="Analyze" onserverclick="btnAnalyze_ServerClick" />
        </div>
        <br />
        <br />
    </div>

    <div class="row" id="result">
        <div class="col-lg-6" id="WordsDiv" visible="false" runat="server">
            <h2>Keywords Frequency</h2>
            <div class="container">
               <div runat="server" id="DivWords">

               </div>
            </div>
        </div>

        <div class="col-lg-6" id="MetaDiv" visible="false" runat="server">
            <h2>Meta data Frequency</h2>
            <div class="container">
                <div runat="server" id="DivMeta">
                  
                </div>
            </div>
        </div>

        <div class=" col-lg-offset-2 col-lg-8" visible="false" id="LinksDiv" runat="server">
            <h2>External Links</h2>
            <div class="container">
                <div runat="server" id="divLinks">
                  
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField Value="" runat="server" ID="hflink" />
    <asp:HiddenField Value="" runat="server" ID="hfmeta" /> 
    <script src="Scripts/jquery-1.10.2.js"></script>
    <script src="Scripts/jquery.dataTables.js"></script>
    <script src="Scripts/dataTables.tableTools.min.js"></script>
    <script>
        $('#links').DataTable();
        $('#words').DataTable();
        $('#meta').DataTable();

    </script>
    <script>
        function checkmeta()
        {
            $('#<%=hfmeta.ClientID%>').val($('#ckMeta').is(':checked'));
        }
        function checklink() {
            $('#<%=hflink.ClientID%>').val($('#ckExternal').is(':checked'));
        }
      /*  function getData() {
            var links = $('#ckExternal').is(':checked');
            var meta = $('#ckMeta').is(':checked');
            var url = $('#url').val();
            var text = $('#text').val();
            if (url == "" && text == "") {
                alert('Please enter a URL or Text to be Analyzed');
            }
            else {
                $.ajax({
                    type: "POST",
                    url: "Default.aspx/Analyze",
                    data: '{meta:' + meta + ', link: ' + links + ', url: "' + url + '", text: "' + text + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var o = response.d;
                        if (o != null) {
                            $("#result").show();
                            if (o.ExternalLinks != null) {
                                $("#LinksDiv").show();
                                var str = JSON.stringify(o.ExternalLinks);
                                $('#LinksTable').bootstrapTable({
                                    data: str
                                });

                            }
                            if (o.WordFrequency != null) {
                                $("#WordsDiv").show();
                                var str = JSON.stringify(o.WordFrequency);
                                $('#WordsTable').bootstrapTable({
                                    data: str
                                });

                            }
                            if (o.MetaTagsFrequency != null) {

                            }
                        }
                        else {
                            alert('No Data')
                        }
                    },
                    error: function (response) {
                        alert(response.responseText);
                    }
                });
            }

        }*/

    </script>
</asp:Content>
