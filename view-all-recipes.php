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
<h3><a href="index.html">Return Home.</a> </h3>
<?php
$db = new db_accessor();
$ret = $db->getRecipes();
//echo $ret;
$rows = $db->CountRecipes();
if ($rows == 0) {
    echo "no recipes match this ID.";
} else {

    //table setup stuff
    echo '<table class="tg"><tr><th class="tg-title" colspan="5">';

    //text in title bar
    echo $rows . " result(s)." . '</th></tr>';

    //echo the table and headings:
    echo '<tr>
    <td class="tg-heading">Recipe ID:</td>
    <td class="tg-heading">Recipe Name:</td>
    <td class="tg-heading">Recipe Tags:</td>
    <td class="tg-heading">Recipe Instructions:</td>
    <td class="tg-heading">Delete?</td></tr>';

    //while there are results to process, echo the stuff out of them:
    while ($row = $ret->fetchArray(SQLITE3_ASSOC)) {
        //row setup stuff
        echo '<tr>';
        echo '<td class="tg-yw4l">' . $row['recipe ID'] . "</td>";
        echo '<td class="tg-yw4l">' . $row['recipe name'] . "</td>";
        echo '<td class="tg-yw4l">' .  $row['recipe tags'] . "</td>";
        echo '<td class="tg-yw4l">' .  $row['recipe instructions'] . "</td>";
        echo '<td><form action="delete-recipe.php" method="post"><input type="hidden" name="rec-to-del" value="' . $row['recipe ID'] . '"><input type="submit" value="delete" ></form></td></tr>';
    }
}
echo "Operation done successfully\n";
$db->close();
?>
</body>
</html>