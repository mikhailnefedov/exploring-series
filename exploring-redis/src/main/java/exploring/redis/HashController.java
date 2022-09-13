package exploring.redis;

import exploring.redis.data.Customer;
import exploring.redis.data.CustomerRepository;
import io.swagger.v3.oas.annotations.parameters.RequestBody;
import org.springframework.data.redis.core.RedisTemplate;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

/**
 * Controller for REST actions for hash data type
 */
@RestController
@RequestMapping(name = "Hash", produces = "application/json", path = "/hash")
public class HashController {

    private final CustomerRepository customerRepository;

    public HashController(CustomerRepository customerRepository) {
        this.customerRepository = customerRepository;
    }

    @GetMapping("Customer")
    public ResponseEntity<Customer> getCustomer(int id) {
        Customer customer = customerRepository.findById(id).get();
        return ResponseEntity.ok(customer);
    }

    @PostMapping()
    public ResponseEntity<Customer> postCustomer(Customer customer) {
        customerRepository.save(customer);
        return ResponseEntity.ok(customer);
    }

}
