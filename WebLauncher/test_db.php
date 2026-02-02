<?php
$host = 'localhost';
$db   = 'wills_world_db';
$user = 'root';
$pass = ''; // Default WampServer password is empty
$charset = 'utf8mb4';

echo "<h1>Database Connection Test</h1>";
echo "<p>Attempting to connect to <strong>$db</strong> at <strong>$host</strong> as user <strong>$user</strong>...</p>";

try {
    $dsn = "mysql:host=$host;dbname=$db;charset=$charset";
    $pdo = new PDO($dsn, $user, $pass);
    echo "<h2 style='color:green'>SUCCESS! Connected to database.</h2>";
} catch (\PDOException $e) {
    echo "<h2 style='color:red'>CONNECTION FAILED</h2>";
    echo "<p><strong>Error Message:</strong> " . $e->getMessage() . "</p>";
    echo "<hr>";
    echo "<h3>Troubleshooting:</h3>";
    echo "<ul>";
    echo "<li>If error says 'Access denied', check if your root user has a password.</li>";
    echo "<li>If error says 'Unknown database', make sure you imported schema.sql.</li>";
    echo "</ul>";
}
?>
