<?php
// WampServer Default Credentials
$host = 'localhost';
$user = 'root';
$pass = ''; // Default is empty
$dbname = 'wills_world_db';

echo "<body style='background:#121212; color:white; font-family:sans-serif; padding:20px;'>";
echo "<h1>🔧 Wills World Auto-Setup</h1>";

// 1. Connect to MySQL (No DB selected yet)
try {
    $pdo = new PDO("mysql:host=$host", $user, $pass);
    $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    echo "<p style='color:#00ff00'>✔ Connected to MySQL server successfully.</p>";
} catch (PDOException $e) {
    die("<p style='color:red'>❌ Could not connect to MySQL. Error: " . $e->getMessage() . "</p></body>");
}

// 2. Create Database
try {
    $pdo->exec("CREATE DATABASE IF NOT EXISTS `$dbname`");
    echo "<p style='color:#00ff00'>✔ Database '$dbname' checked/created.</p>";
    $pdo->exec("USE `$dbname`");
} catch (PDOException $e) {
    die("<p style='color:red'>❌ Failed to create database. Error: " . $e->getMessage() . "</p></body>");
}

// 3. Create Users Table
try {
    $sql = "CREATE TABLE IF NOT EXISTS users (
        id INT AUTO_INCREMENT PRIMARY KEY,
        username VARCHAR(50) NOT NULL UNIQUE,
        password VARCHAR(255) NOT NULL,
        created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
    )";
    $pdo->exec($sql);
    echo "<p style='color:#00ff00'>✔ Table 'users' checked/created.</p>";
} catch (PDOException $e) {
    die("<p style='color:red'>❌ Failed to create table. Error: " . $e->getMessage() . "</p></body>");
}

echo "<hr>";
echo "<h2>🎉 Setup Complete!</h2>";
echo "<p>You can now <a href='login.php' style='color:#00DBDE; font-size:1.2em;'>Go to Login Page</a></p>";
echo "</body>";
?>
