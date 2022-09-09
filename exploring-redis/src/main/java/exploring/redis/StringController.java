package exploring.redis;

import org.springframework.data.redis.core.RedisTemplate;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.time.Duration;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;

/**
 * Controller for REST actions for string data type
 */
@RestController
@RequestMapping(name = "String", produces = "application/json", path = "/string")
public class StringController {

    private final RedisTemplate<String, Object> template;

    public StringController(RedisTemplate<String, Object> template) {
        this.template = template;
    }

    /**
     * Gets the value of a key
     */
    @GetMapping()
    public ResponseEntity getValue(String key) {
        String value = (String) template.opsForValue().get(key);
        return ResponseEntity.ok(Collections.singletonMap(key, value));
    }

    /**
     * Gets the value of a key
     */
    @GetMapping("Values")
    public ResponseEntity getValues(@RequestParam List<String> keys) {
        List<Object> values = template.opsForValue().multiGet(keys);
        HashMap<String, String> responseMap = new HashMap<String, String>();
        for (int i = 0; i < keys.size(); i++) {
            responseMap.put(keys.get(i), (String) values.get(i));
        }

        return ResponseEntity.ok(responseMap);
    }

    /**
     * Sets a value of a key
     */
    @PostMapping()
    public ResponseEntity postValue(String key, String value) {
        template.opsForValue().set(key, value);
        return ResponseEntity.ok(Collections.singletonMap(key, value));
    }

    @PostMapping("StringWithAutomaticExpiration")
    public ResponseEntity postStringWithAutomaticExpiration(String key, String value, int expirationSeconds) {
        template.opsForValue().set(key, value, Duration.ofSeconds(expirationSeconds));
        return ResponseEntity.ok(Collections.singletonMap(key, value));
    }

    @DeleteMapping()
    public ResponseEntity deleteValue(String key) {
        String value = (String) template.opsForValue().getAndDelete(key);

        return ResponseEntity.ok(Collections.singletonMap(key, value));
    }

    @PostMapping("Counter")
    public ResponseEntity postCounter(String counterKey, int counterValue) {
        template.opsForValue().set(counterKey, counterValue);
        return ResponseEntity.ok(Collections.singletonMap(counterKey, counterValue));
    }

    @PutMapping("IncreaseCounter")
    public ResponseEntity increaseCounter(String key) {
        long value = template.opsForValue().increment(key);
        return ResponseEntity.ok(Collections.singletonMap(key, value));
    }
}
