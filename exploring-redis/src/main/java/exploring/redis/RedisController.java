package exploring.redis;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping(name = "Redis", produces = "application/json", path = "/redis")
public class RedisController {


    @GetMapping()
    public ResponseEntity getTest() {
        return ResponseEntity.ok("test");
    }
}
