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
$toinsert = array($_POST['name'], $_POST['desc']);

$result = $mydb->AddIngredient($toinsert[0], $toinsert[1]);

//we done, move on:
header('Location: /quem/insert-ingredient.html');