package de.mikhailnefedov.exploringmongodb.data;

import de.mikhailnefedov.exploringmongodb.models.Article;

import java.util.ArrayList;
import java.util.List;

public class InitData {

    public static List<Article> getArticles() {
        return new ArrayList<Article>(List.of(
                Article.builder()
                        .id(1)
                        .name("Toaster Deluxe")
                        .price(29.99)
                        .description("Toaster Deluxe is a perfect Toaster for your breakfast.")
                        .tags(List.of("breakfast","bread"))
                        .build(),
                Article.builder()
                        .id(2)
                        .name("Knife 5cm")
                        .price(9.99)
                        .description("Simple knife for cutting veggies and fruits.")
                        .build(),
                Article.builder()
                        .id(3)
                        .name("Knife Sharpener Extreme")
                        .price(19.99)
                        .description("Sharpens a kitchen knife fast and efficiently.")
                        .build(),
                Article.builder()
                        .id(4)
                        .name("Pot 24cm")
                        .price(49.99)
                        .description("Pot for making soup, ...")
                        .tags(List.of("soup"))
                        .build(),
                Article.builder()
                        .id(5)
                        .name("Potato Peeler Classic")
                        .price(7.99)
                        .description("Want to peel off the skin of a potato? Use the Potato Peeler Classic")
                        .tags(List.of("potato"))
                        .build()
        ));
    }
}
