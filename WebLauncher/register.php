<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Register - Wills World</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <div class="container">
        <div class="card">
            <h2>Join the Adventure</h2>
            <form onsubmit="handleAuth(event, 'register')">
                <div class="form-group">
                    <label>Choose Username</label>
                    <input type="text" name="username" required>
                </div>
                <div class="form-group">
                    <label>Password</label>
                    <input type="password" name="password" required>
                </div>
                <button type="submit" class="btn">Register</button>
            </form>
            <div class="link-text">
                Already have an account? <a href="login.php">Login</a>
            </div>
        </div>
    </div>
    <script src="script.js"></script>
</body>
</html>
