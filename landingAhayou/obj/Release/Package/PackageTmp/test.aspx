<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="landingAhayou.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title>Flowplayer Embed Example</title>
     <script>
         // Wait for Flowplayer to fully load and initialize the player
         document.addEventListener("flowplayer-ready", function (event) {
             const player = event.detail;

             // Add 'ended' event listener
             player.on("ended", function () {
                 console.log("Video has ended!");
                 // You can add any additional logic here
             });
         });
     </script>
</head>
    
<body>
    <form id="form1" runat="server">
        <div id="async-player" data-player-id="cdcc4202-ef0b-4e03-a43a-d1fcf6d83157">
            <script src="//cdn.flowplayer.com/players/ffdf2c44-aa29-4df8-a270-3a199a1b119e/native/flowplayer.async.js">
                {
                  "src": "f576651c-4cc6-4664-84fa-bb3b35ef1aba"
                }
            </script>
        </div>

       
    </form>
</body>
</html>
