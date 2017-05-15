<?php
/**
 * Created by PhpStorm.
 * User: Fudge
 * Date: 15/05/2017
 * Time: 3:48 PM
 */

namespace chibo;


class db_accessor extends \SQLite3
{
    function __construct()
    {
        $this->open();
    }

    function open()
    {
        parent::open('/opt/sqlitedb/chibo_db.db3');
    }

    function close()
    {
        parent::close();
    }

    function getRecipes ()
    {
        //gets an array of recipes
        $sql = <<<EOF
SELECT recipes.id AS "recipe ID", recipes.name AS "recipe name", recipes.tags AS "recipe tags", ingredients.id AS "ingredient id", ingredients.name AS "ingredient name" from recipes INNER JOIN ingredientInRecipe ON ingredientInRecipe.recipeID = recipes.ID INNER JOIN ingredients ON ingredients.id = ingredientInRecipe.ingredientID;
EOF;
        return parent::query($sql);
    }

    function getRecipe($id)
    {
        //returns details for a recipe with the ID, and associated ingredients
        $sql = <<<EOF
SELECT recipes.id AS "recipe ID", recipes.name AS "recipe name", recipes.tags AS "recipe tags", ingredients.id AS "ingredient id", ingredients.name AS "ingredient name" from recipes INNER JOIN ingredientInRecipe ON ingredientInRecipe.recipeID = recipes.ID INNER JOIN ingredients ON ingredients.id = ingredientInRecipe.ingredientID WHERE recipes.id = $id;
EOF;
        return parent::query($sql);

    }

    function getRecipesAndIngredients ()
    {
        //gets an array of recipes with their ingredients.
    }

    function AddRecipe($name, $instructions, $tags)
    {
        //add a recipe with the three required things.
        $sql = <<<EOF
INSERT INTO recipes [(name, instructions, tags)] VALUES ($name, $instructions, $tags);
EOF;
        return parent::query($sql);
    }

    //TODO: add an overload for AddRecipe with image or some shit
}