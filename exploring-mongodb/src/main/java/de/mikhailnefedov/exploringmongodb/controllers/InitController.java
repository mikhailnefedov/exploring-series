package de.mikhailnefedov.exploringmongodb.controllers;

import de.mikhailnefedov.exploringmongodb.data.InitData;
import de.mikhailnefedov.exploringmongodb.repositories.ArticleRepository;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.Collections;

/**
 * For loading init data into the database
 */
@RestController
@RequestMapping(name = "Init", produces = "application/json", path = "/init")
public class InitController {

    private ArticleRepository articleRepository;

    public InitController(ArticleRepository articleRepository) {
        this.articleRepository = articleRepository;
    }

    @PostMapping()
    public ResponseEntity post() {
        articleRepository.saveAll(InitData.getArticles());
        return ResponseEntity.ok(Collections.singletonMap("message", "Initialization complete"));
    }

    @DeleteMapping()
    public ResponseEntity delete() {
        articleRepository.deleteAll();
        return ResponseEntity.ok(Collections.singletonMap("message", "Delete complete"));
    }
}
