<?php
namespace chibo;
require "db_accessor.php";
/**
 * Created by PhpStorm.
 * User: Fudge
 * Date: 15/05/2017
 * Time: 10:13 PM
 */
if (!isset($_POST['ing-to-del'])) {
    //value not set. idk how we got here. get tf out.
    echo 'value not set. try <a href="view-all-ingredients.php">going back.</a>';
} else {
    //POST value set. we know what to delete.
    $mydb = new db_accessor();
    $result = $mydb->deleteIngredient($_POST['ing-to-del']);
    echo $result;

}