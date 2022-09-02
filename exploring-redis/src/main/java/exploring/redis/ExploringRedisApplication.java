package exploring.redis;

import io.swagger.v3.oas.models.OpenAPI;
import io.swagger.v3.oas.models.info.Info;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;

@SpringBootApplication
public class ExploringRedisApplication {

    public static void main(String[] args) {
        SpringApplication.run(ExploringRedisApplication.class, args);
    }

    @Bean
    public OpenAPI api() {
        return new OpenAPI()
                .info(new Info().title("Exploring-Redis"));
    }

}
