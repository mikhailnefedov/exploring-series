package exploring.redis;

import exploring.redis.data.Customer;
import exploring.redis.data.CustomerRepository;
import org.springframework.data.redis.core.RedisTemplate;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.Collections;

/**
 * Controller for REST actions for set data type
 */
@RestController
@RequestMapping(name = "Set", produces = "application/json", path = "/set")
public class SetController {

    private final RedisTemplate<String, Object> template;

    public SetController(RedisTemplate<String, Object> template) {
        this.template = template;
    }

    @GetMapping("CheckIfInList")
    public ResponseEntity checkIfInList(String key, String value) {
        boolean result = template.opsForSet().isMember(key, value);
        return ResponseEntity.ok(Collections.singletonMap("result", result));
    }

    @PostMapping()
    public ResponseEntity postCustomer(String key, String... values) {
        long result = template.opsForSet().add(key, values);
        return ResponseEntity.ok(Collections.singletonMap("result", result));
    }

}
