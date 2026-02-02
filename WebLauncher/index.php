<?php
require 'auth_check.php';
requireLogin();
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Wills World - Dashboard</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <!-- User Menu -->
    <div class="user-menu">
        <div class="user-icon" onclick="toggleMenu()">
            <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="white" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                <path d="M20 21v-2a4 4 0 0 0-4-4H8a4 4 0 0 0-4 4v2"></path>
                <circle cx="12" cy="7" r="4"></circle>
            </svg>
        </div>
        <div id="userDropdown" class="dropdown">
            <div style="padding:5px; color:#aaa; font-size:0.8em; border-bottom:1px solid #333; margin-bottom:5px;">
                <?php echo htmlspecialchars($_SESSION['username']); ?>
            </div>
            <a href="#" onclick="handleAuth(event, 'logout')">Logout</a>
        </div>
    </div>

    <!-- Main Content -->
    <div class="bubble-container">
        <div class="launch-bubble" onclick="launchGame()">
            Launch Game
        </div>
    </div>

    <script src="script.js"></script>
</body>
</html>
