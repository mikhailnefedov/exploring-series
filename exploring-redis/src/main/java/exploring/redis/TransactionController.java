package exploring.redis;

import org.springframework.dao.DataAccessException;
import org.springframework.data.redis.core.RedisOperations;
import org.springframework.data.redis.core.RedisTemplate;
import org.springframework.data.redis.core.SessionCallback;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.Collections;
import java.util.HashMap;
import java.util.List;

/**
 * Controller to try out transcations
 */
@RestController
@RequestMapping(name = "Transaction", produces = "application/json", path = "/transaction")
public class TransactionController {

    private RedisTemplate<String, Object> template;

    public TransactionController(RedisTemplate<String, Object> template) {
        this.template = template;
    }

    @PostMapping()
    public ResponseEntity postData() {
        List<Object> txResult = template.execute(new SessionCallback<List<Object>>() {
            @Override
            public <K, V> List<Object> execute(RedisOperations<K, V> operations) throws DataAccessException {
                operations.multi();
                template.opsForValue().set("transaction:string", "just a string");
                template.opsForList().leftPush("transaction:list", 1);
                return operations.exec();
            }
        });
        HashMap<String, Object> resultMap = new HashMap<>();
        resultMap.put("transaction:string", txResult.get(0));
        resultMap.put("transaction:list", txResult.get(1));
        return ResponseEntity.ok(resultMap);
    }

    @GetMapping()
    public ResponseEntity getData() {
        List<Object> txResult = template.execute(new SessionCallback<List<Object>>() {
            @Override
            public <K, V> List<Object> execute(RedisOperations<K, V> operations) throws DataAccessException {
                operations.multi();
                template.opsForValue().get("transaction:string");
                template.opsForList().range("transaction:list", 0, Integer.MAX_VALUE);
                return operations.exec();
            }
        });
        HashMap<String, Object> resultMap = new HashMap<>();
        resultMap.put("string", txResult.get(0));
        resultMap.put("list", txResult.get(1));
        return ResponseEntity.ok(resultMap);
    }
}
