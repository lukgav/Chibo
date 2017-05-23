<?php
namespace chibo;
/**
 * Created by PhpStorm.
 * User: Fudge
 * Date: 15/05/2017
 * Time: 5:54 PM
 */
require "db_accessor.php";
//setup DB
$mydb = new db_accessor();
echo "<pre>";
print_r($_POST);
echo "</pre>";

$links = [];
for ($x = 0; $x < $_POST['numLinks']; $x++) {
    //how the fuck does this work
    $ing = "ingredient" . $x;
    $qty = "qty-" . $x;
    $mod = "mod-" . $x;
    $inglnk = array('ing' => $_POST[$ing], 'qty' => $_POST[$qty], 'mod' => $_POST[$mod]);
    array_push($links, $inglnk);
}
echo "<pre>";
print_r($links);
echo "</pre>";

$result = $mydb->AddLinks($links, $_POST['recipeID'] );

//if ($result->numColumns() == 0) {
//    //we out here

echo 'Done. you can <a href="create-link.php">add another </a>or you can <a href="view-all-recipes.php">view all recipes.</a>'
?>