package exploring.redis.data;

import lombok.Data;
import org.springframework.data.annotation.Id;
import org.springframework.data.redis.core.RedisHash;

import java.util.ArrayList;

@Data
@RedisHash("customer")
public class Customer {
    @Id
    private int id;
    private String firstName;
    private String lastName;
    private String address;
    private ArrayList<String> emails;
}
