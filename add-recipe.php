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

//extract POST data to our own array.
$toinsert = array($_POST['recipename'], $_POST['instructions'], $_POST['tags']);

$result = $mydb->AddRecipe($toinsert[0], $toinsert[1], $toinsert[2]);

if ($result->numColumns() == 0) {
    //we out here
    echo 'Done. you can <a href="insert-recipe.html">add another </a>or you can <a href="view-all-recipes.php">view all recipes.</a>';
}