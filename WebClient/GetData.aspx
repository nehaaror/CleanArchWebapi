<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetData.aspx.cs" Inherits="WebClient.GetData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <script src="Scripts/jquery-3.4.1.min.js"></script>
        <script src="Scripts/jquery.unobtrusive-ajax.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btngetdata").click(function () {
                $.ajax({
                    type: "GET",
                    url: "https://localhost:44311/api/example",
                    success: function (data) {
                        console.log(data);
                    },
                    error: function (err) {
                        console.log("Error in reading");
                    }

                });
            });
        });
        

        
    </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <input type="button" value="Getdata" id="btngetdata" />

        <div>
        </div>
    </form>
</body>
</html>
