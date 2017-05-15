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
<?php
$db = new db_accessor();
$ret = $db->getRecipe(1);   //TODO: add get/post style ID updating.
//echo $ret;
$rows = count($ret);
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
    <td class="tg-heading">Ingredient ID:</td>
    <td class="tg-heading">Ingredient Name:</td></tr>';

    //while there are results to process, echo the stuff out of them:
    while ($row = $ret->fetchArray(SQLITE3_ASSOC)) {
        //row setup stuff
        echo '<tr>';
        echo '<td class="tg-yw4l">' . $row['recipe ID'] . "</td>";
        echo '<td class="tg-yw4l">' . $row['recipe name'] . "</td>";
        echo '<td class="tg-yw4l">' .  $row['recipe tags'] . "</td>";
        echo '<td class="tg-yw4l">' .  $row['ingredient id'] . "</td>";
        echo '<td class="tg-yw4l">' .  $row['ingredient name'] . "</td>";
    }
}
echo "Operation done successfully\n";
$db->close();
?>
</body>
</html>