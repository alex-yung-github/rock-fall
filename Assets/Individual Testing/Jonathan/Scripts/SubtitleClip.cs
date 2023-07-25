using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SubtitleClip : PlayableAsset
{
    public string subtitleText;
    public string characterName;
    public int dialogueSize;
    // Start is called before the first frame update

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<SubtitleBehavior>.Create(graph);
        SubtitleBehavior subtitleBehavior = playable.GetBehaviour();
        subtitleBehavior.subtitleText = subtitleText;

        return playable;
    }
  
}
