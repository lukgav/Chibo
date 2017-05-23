<?php
namespace chibo;
require "db_accessor.php";
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <link rel="stylesheet" href="css/table.css">
    <meta charset="UTF-8">
    <title>Viewing all entries in DB</title>
    <link rel="icon" href="assets/icon.ico" type="image/x-icon">
</head>
<body>
<h3><a href="index.html">return home.</a> </h3>
<?php
$db = new db_accessor();
if (!isset($_GET['id'])) {
    //id wasn't pushed in the GET method. use 1.
    $ret = $db->getRecipe(1);
} else {
    $ret = $db->getRecipe($_GET['id']);
}

$rows = count($ret);
if ($rows == 0) {
    echo "no recipes match this ID.";
} else {
    //table setup stuff
    echo '<table class="tg"><tr><th class="tg-title" colspan="4">';

    //text in title bar
    echo $rows . " result(s)." . '</th></tr>';

    //echo the table and headings:
    ?>
    <tr>
    <td class="tg-heading">Recipe ID:</td>
    <td class="tg-heading">Recipe Name:</td>
    <td class="tg-heading">Recipe Tags:</td>
    <td class="tg-heading">Recipe Instructions:</td>
<?php

    //while there are results to process, echo the stuff out of them:
    while ($row = $ret->fetchArray(SQLITE3_ASSOC)) {
        //row setup stuff
        echo '<tr>';
        echo '<td class="tg-yw4l">' . $row['recipe id'] . "</td>";
        echo '<td class="tg-yw4l">' . $row['recipe name'] . "</td>";
        echo '<td class="tg-yw4l">' .  $row['recipe tags'] . "</td>";
        echo '<td class="tg-yw4l">' .  $row['recipe instructions'] . "</td></tr>";
    }
echo "</table>";
}
$db->close();
?>

<br><br><h2>View a different recipe instead</h2>
<form action="view-recipe-id.php" method="get">
    ID: <br>
    <input type="text" name="id"><br>
    <input type="submit" value="view new ID">
</form>
<br><br>
</body>
</html>