package exploring.redis;

import org.springframework.data.redis.core.RedisTemplate;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping(name = "Redis", produces = "application/json", path = "/redis")
public class RedisController {

    private final RedisTemplate<String, Object> template;

    public RedisController(RedisTemplate<String, Object> template) {
        this.template = template;
    }

    @GetMapping()
    public ResponseEntity getTest() {
        Object result = template.opsForValue().get("key:1");
        return ResponseEntity.ok(result);
    }
}
