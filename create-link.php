<?php
//WOW NICE MEME
namespace chibo;
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <link rel="stylesheet" href="css/table.css">
    <meta charset="UTF-8">
    <title>create a new recipe-ingredients link</title>
    <link rel="icon" href="assets/icon.ico" type="image/x-icon">
</head>
<body>
<h1>Add a new recipe:</h1>
<br><hr>
<?php
require "db_accessor.php";

$mydb = new db_accessor();
$ret = $mydb->selectFirstUnlinkedRecipe();
//set up table

echo '<table class="tg"><tr><th class="tg-title" colspan="2">';

//text in title bar
echo " result(s)." . '</th></tr>'; //$rows .

//echo the table and headings:
?>
<tr>
    <td class="tg-heading">Recipe ID:</td>
    <td class="tg-heading">Recipe Name:</td>

    <?php

    //while there are results to process, echo the stuff out of them:
    while ($row = $ret->fetchArray(SQLITE3_ASSOC)) {
        //row setup stuff
        echo '<tr>';
        echo '<td class="tg-yw4l">' . $row['recipe id'] . "</td>";
        echo '<td class="tg-yw4l">' . $row['recipe name'] . "</td></tr>";
    }
echo "</table>";
$mydb->close();
?>

<form action="add-ingredient.php" method="post">
    Ingredient name:<br>
    <input type="text" name="name"><br>

    Ingredient description.<br>
    <input type="text" name="desc" size="50"><br>

    <input type="submit" value="Submit"><br><br>
</form>
<br><br><br><h3><a href="index.html">Go home.</a></h3>
</body>
</html>