<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test_wowza.aspx.cs" Inherits="landingAhayou.test_wowza" %>

<!DOCTYPE html>
<html>
<head>
  <title>Flowplayer Ended Event with jQuery</title>
  <link rel="stylesheet" href="https://releases.flowplayer.org/7.2.7/skin/skin.css">
  <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
  <script src="https://releases.flowplayer.org/7.2.7/flowplayer.min.js"></script>
</head>
<body>
 <form id="form1" runat="server">
     <div id="videoPlayer" data-ratio="0.5625">
       <script src="//cdn.flowplayer.com/players/ffdf2c44-aa29-4df8-a270-3a199a1b119e/native/flowplayer.async.js">
           {
             "src": "f576651c-4cc6-4664-84fa-bb3b35ef1aba"
           }
         </script>
    </div>
<%--<div id="async-player" class="flowplayer" >
  <script src="//cdn.flowplayer.com/players/ffdf2c44-aa29-4df8-a270-3a199a1b119e/native/flowplayer.async.js">
    {
      "src": "f576651c-4cc6-4664-84fa-bb3b35ef1aba"
    }
  </script>
</div>--%>
</form>


</body>
    <script>
        $(document).ready(function () {
            flowplayer('#videoPlayer').on('ended', function (e, api) {
                console.log('Video has ended (handled via jQuery).');

                // Example: jQuery action when video ends
                $('#videoPlayer').after('<p>Thanks for watching!</p>');
            });
        });
    </script>
   <%-- <script>
        // Attach the ended event
        flowplayer('#async-player').on('ended', function (e, api) {
            alert("Thanks for watching!");
        });
    </script>--%>
</html>
