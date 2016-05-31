public enum PowerType {
    Fire, Speed, Zip, Spring, None
}

public interface Power {

    bool WillChangeVelocity();

    float GetXVelocity(float xvelocity);

    float GetYVelocity(float yvelocity);

    void Update();
}
