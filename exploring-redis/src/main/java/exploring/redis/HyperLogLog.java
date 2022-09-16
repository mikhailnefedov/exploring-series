package exploring.redis;

import org.springframework.data.redis.core.RedisTemplate;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.Collections;

/**
 * Controller for REST actions for HyperLogLog data type
 */
@RestController
@RequestMapping(name = "HyperLogLog", produces = "application/json", path = "/hyperloglog")
public class HyperLogLog {

    private final RedisTemplate<String, Object> template;

    public HyperLogLog(RedisTemplate<String, Object> template) {
        this.template = template;
    }

    @GetMapping("count")
    public ResponseEntity count(String key) {
        Long result = template.opsForHyperLogLog().size(key);
        return ResponseEntity.ok(Collections.singletonMap("result", result));
    }

    @PostMapping()
    public ResponseEntity postValues(String key, String... values) {
        long result = template.opsForHyperLogLog().add(key, values);
        return ResponseEntity.ok(Collections.singletonMap("result", result));
    }

}
