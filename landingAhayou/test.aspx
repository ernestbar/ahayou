<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="landingAhayou.test" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="manifest" href="manifest2.json">
    <link rel="apple-touch-icon" href="icon-192x192.png"> <!-- Placeholder for apple-touch-icon -->
    <title>PWA Sample App</title>
    <script>
        if ('serviceWorker' in navigator) {
            window.addEventListener('load', () => {
                navigator.serviceWorker.register('service-worker.js')
                    .then(registration => {
                        console.log('Service Worker registered with scope:', registration.scope);
                    })
                    .catch(error => {
                        console.error('Service Worker registration failed:', error);
                    });
            });
        }
    </script>
    <style>
        /* Moved styles for Install Button */
        #install-button {
            display: none;
            position: fixed;
            bottom: 20px;
            right: 20px;
            padding: 10px 20px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        /* Moved styles for iOS Instructions */
        #ios-instructions {
            display: none;
            position: fixed;
            bottom: 20px;
            left: 20px;
            padding: 10px;
            background-color: #f7f7f7;
            border: 1px solid #ddd;
            border-radius: 5px;
            max-width: 300px;
        }

        /* Moved styles for iOS Close Button */
        #ios-close-btn {
            padding: 5px 10px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f4;
        }

        header {
            background: #333;
            color: #fff;
            padding: 10px 0;
            text-align: center;
        }

        main {
            padding: 20px;
        }

        footer {
            text-align: center;
            padding: 10px 0;
            background: #333;
            color: #fff;
            position: fixed;
            width: 100%;
            bottom: 0;
        }
    </style>
</head>

<body>
   <div class="flowplayer-embed-container" style="position: relative; padding-bottom: 56.25%; height: 0; overflow: hidden; max-width:100%;">          <iframe webkitAllowFullScreen mozallowfullscreen allowfullscreen src="https://ljsp.lwcdn.com/api/video/embed.jsp?id=d30d20f7-b073-4f6f-bac4-370e1b686050&pi=cb8bd2b7-897f-4e9f-a9fd-7179f891e6b4" title="0" byline="0" portrait="0" frameborder="0" allow="autoplay" style="position: absolute; top: 0; left: 0; width: 500px; height: 300px;"></iframe>        </div>
    
</body>

</html>