using UnityEngine;

public class FoodScript : MonoBehaviour
{
    public int foodType;
    FoodEvent foodEvent;
    
    private void Start()
    {
        foodEvent = new FoodEvent();
        foodEvent.onEat += new FoodEvent.foodHandler(onEatFood);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            foodEvent.eatFood(foodType);
        }
    }

    void onEatFood(int foodType)
    {
        switch (foodType)
        {
            case 1:
                Debug.Log("foodtype 1");
                break;
            case 2:
                Debug.Log("foodtype 2");
                break;
            case 3:
                Debug.Log("foodtype 3");
                break;
        }

    }
}
