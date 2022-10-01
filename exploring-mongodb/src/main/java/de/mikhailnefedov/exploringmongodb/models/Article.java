package de.mikhailnefedov.exploringmongodb.models;

import lombok.Builder;
import lombok.Data;
import org.springframework.data.mongodb.core.mapping.Document;
import org.springframework.data.mongodb.core.mapping.MongoId;

import java.util.List;

@Data
@Builder
@Document
public class Article {
    @MongoId
    private int id;
    private String name;
    private double price;
    private String description;
    private List<String> tags;
}
