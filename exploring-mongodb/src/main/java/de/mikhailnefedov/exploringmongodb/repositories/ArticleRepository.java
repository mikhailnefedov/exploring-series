package de.mikhailnefedov.exploringmongodb.repositories;

import de.mikhailnefedov.exploringmongodb.models.Article;
import org.springframework.data.mongodb.repository.MongoRepository;

public interface ArticleRepository extends MongoRepository<Article, Integer> {
}
