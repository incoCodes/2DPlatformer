# 2DPlatformer

Hello Welcome to my 2D platformer repository.

I will have all source code and resources from my 2D game here.

Lookout for:
1. PlayerMovement Source code 
2. Assets 
3. Animation Files
4. Demo Scenes 
5. Art
6. Credits 
7. ~Yakuza 4~

Timeline aka Roadmap:

| Date          |Semester Milestone|Project Milestone                                                                                                          |
| ------------- |:----------------:|-------------------------------------------------------------------------------------------------------------------------- |        
| Sun, 09 12    | Deliverable 1    |I prepare assets for a prototype and just learn my way around the Unity Engine as well as refine some of my C# Skills.     |
| Sun, 09 26    | Deliverable 2    |I start learning design and animations for the game.                                                                       |
| Sun, 10 10    | Deliverable 3    |Start building the main game                                                                                               |  
| 10-13 to 10-18| N/A              | On break. . .                                                                                                             | 
| Mon, 11 01    | Deliverable 4    | I start fixing any bugs and smoothing movements as well as start adding basic AI enemies.                                 |
| Mon, 11 15    | Deliverable 5    | I ask my peers in computer coding 2 as well as anyone who is willing to playtest my game for feedback                     |
| Sun, 11 28    | Deliverable 6    | I use the feedback to make my game better.                                                                                |
| Sun 12 12     | Deliverable 7    | I have documented my progress from start to finish and compare the start result to the end result.                        |
| Wed, 11 24    | Deliverable 8    | I finish my project.                                                                                                      |


 What was your goal for this deliverable, as defined on your Learning Plan?
 I just wanted to make a README file as well as open a Repo in order to have a place to put my code and resources in.
 Did you meet this goal? If not, why?
 Yeah I did, Making a repo is not that difficult.

  What needs to happen for you to stay on schedule from this point forward (e.g., change of plan, putting in extra time, getting help, etc.)?
  I need to just manage my time and use my time as wisely and efficiently as possible.
  
  
  
 # Examples of Source code:
  
 ## First iteration of my PlayerMovement.cs script
```  
     void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * speed * Time.deltaTime * horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            _ridbod.AddForce(Vector2.up * jumpForce);
            isJumping = true;
        }

        if(Input.GetKeyDown(KeyCode.B))
        {
           
            _amrbod.material.color = Color.grey;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            
           _amrbod.material.color = Color.white;
        }



        if (_amrbod.material.color == Color.white)
        {
            Respawn(blackPosition);
        }

        if (_amrbod.material.color == Color.grey)
        {
            Respawn(whitePosition);
        }




    }
 ```
 # A summary of my learning
 
 In this project I think I've made some good progress when it comes to being a better programmer and video game developer, before I would watch youtube videos and follow how they would write the code step by step, but in this project I was able to use more of my own thinking and writing my own code it was more independent, obviously I did have to research how to do a few of the mechanics such as the rope physics as well as how to attach the player to the rope and swing (Please refer to rope.cs and ropeSegment.cs for examples), but I was able to tweak a few things that would make it fit with the program. Although the project didn't have anything to flashy or have a lot of functionality in terms of the mechanics it did help me exit my comfort zone a little more as well as be used as evidence that I am more capable of doing better games in the future.
 
 
 # Feedback on the game
 
 For the feedback I wanted to ask people who have a solid understanding of video game design and mechanics of course I'm not expecting them to understand it like an acutal developer would but I would like some sort of background or validity when it comes to giving me the feedback, I asked my friends to play test the game for me. I wasn't worried that there would be some bias when it comes to the feedback because my friends would take this seriously if you asked to take it seriously which is what I did, any sort of feedback wouldn't be able to hurt me since I am open to any type of critisim as this isn't my life long work, so after getting the feedback from them I would start to look at what are the most common topics of feedback that I am getting from everyone, then after addressing the most common probelm I would check if I can fix any quality of life issues such as make exit button or a pause menu, of course I wouldn't fix every single problem due to the fact that some of them can be subjective to the person but I would try to fix the most objective ones. 
 
 
 # License 
 
 MIT License, Please refer to the License file for more information.
 
 
 






