package de.mikhailnefedov.exploringmongodb.controllers;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping(name = "Init", produces = "application/json", path = "/init")
public class InitController {

    @GetMapping()
    public ResponseEntity<String> get() {
        return ResponseEntity.ok("init");
    }
}
