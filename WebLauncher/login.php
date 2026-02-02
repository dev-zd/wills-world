<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login - Wills World</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <div class="container">
        <div class="card">
            <h2>Wills World Login</h2>
            <form onsubmit="handleAuth(event, 'login')">
                <div class="form-group">
                    <label>Username</label>
                    <input type="text" name="username" required>
                </div>
                <div class="form-group">
                    <label>Password</label>
                    <input type="password" name="password" required>
                </div>
                <button type="submit" class="btn">Enter World</button>
            </form>
            <div class="link-text">
                New here? <a href="register.php">Create Account</a>
            </div>
        </div>
    </div>
    <script src="script.js"></script>
</body>
</html>
