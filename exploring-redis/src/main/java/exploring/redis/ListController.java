package exploring.redis;

import org.springframework.data.redis.core.RedisTemplate;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.Collections;
import java.util.List;

/**
 * Controller for REST actions for list data types
 */
@RestController
@RequestMapping(name = "List", produces = "application/json", path = "/list")
public class ListController {

    private final RedisTemplate<String, Object> template;

    public ListController(RedisTemplate<String, Object> template) {
        this.template = template;
    }

    @PutMapping("LeftPush")
    public ResponseEntity leftPush(String key, String value) {
        template.opsForList().leftPush(key, value);
        long size = template.opsForList().size(key);
        List<Object> result = template.opsForList().range(key, 0, size);
        return ResponseEntity.ok(Collections.singletonMap(key, result));
    }

    @PutMapping("LeftPop")
    public ResponseEntity leftPop(String key) {
        template.opsForList().leftPop(key);
        long size = template.opsForList().size(key);
        List<Object> result = template.opsForList().range(key, 0, size);
        return ResponseEntity.ok(Collections.singletonMap(key, result));
    }

}
