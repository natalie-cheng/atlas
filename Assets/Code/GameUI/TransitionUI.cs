using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TransitionUI : MonoBehaviour
{
    // UI object
    public static TransitionUI Singleton;

    // text object
    public TextMeshProUGUI textContent;

    private string scene;

    private void Start()
    {
        LoadText(GameUI.levelTrack);
    }

    // level track is one below the corresponding level
    // ie level 0 displays the transition between level 0-1
    private void LoadText(int level)
    {
        if (level==0)
        {
            textContent.text = "You, Atlas, have just stolen the precious Golden Fleece! After your daring escape from Colchis, " +
                "you set sail home to Atlassos with your prize – until a brutal storm hits, kills your crew, destroys your boat, and " +
                "strands you on an island in the middle of nowhere. Now, you must survive and fight your way through mythological " +
                "perils to find your way home!";
            scene = "Level 1";
        }
        else if (level == 1)
        {
            textContent.text = "You made it off the island! You don’t have much time to rest though – you suddenly realize you've " +
                "sailed right into the Strait of Messina, where the infamous Scylla and Charybdis await. According to legend, Scylla " +
                "is a cursed monster who attacks anything within reach and Charybdis is a deadly whirlpool who will suck in anything " +
                "that gets close. As you approach, you realize they’ve multiplied! Survive and navigate safely through the Scyllas " +
                "and Charybdises to get one step closer to home.";
            scene = "Level 2";
        }
        else if (level == 2)
        {
            textContent.text = "Whew ! You survived all those Scyllas and Charybdises. However, as you near Greece, you’re suddenly " +
                "attacked by the vicious Stymphalian birds. These monstrous birds are known for their bronze beaks, razor-sharp " +
                "feathers, and carnivorous appetite. As they swarm around you, you whip out your bow and arrow and desperately try to " +
                "slay them all before they peck you to death!";
            scene = "Level 3";
        }
        else if (level == 3)
        {
            textContent.text = "You finally got rid of all those annoying birds! Unfortunately, Zeus is  offended that you murdered " +
                "all the birds, and is chasing you across the ocean. Escape his wrath by dodging his deadly lightning bolts, weaving " +
                "through rocks, and utilizing helpful currents to speed you along the way!";
            scene = "Level 4";
        }
        else if (level == 4)
        {
            textContent.text = "You’ve finally reached land and gotten off that cursed boat, and you’re so close to home you can almost " +
                "see it in the distance – you stop at a nearby cave for a night’s rest though, planning to make your heroic return the " +
                "next morning. After an uncomfortable night’s sleep on the cold cave floor, you wake up to a shocking sight – a group of " +
                "cyclopes staring at their next breakfast! You rush to draw your sword and fend them off for as long as you can.";
            scene = "Level 5";
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(scene);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
