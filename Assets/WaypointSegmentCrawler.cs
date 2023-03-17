using System;
using System.Collections.Generic;

using UnityEngine;

using static WaypointNode;


public class WaypointSegmentCrawler{
    private WaypointNode head;
    private WaypointNode currentnode;

    public WaypointSegmentCrawler(WaypointNode head){
        this.head = head;
        this.currentnode = head;
    }

    public IEnumerable<WaypointNode> Crawl() {
        while(this.currentnode.forwardnodes.Count == 1){
            this.currentnode = this.currentnode.forwardnodes[0];
            yield return this.currentnode;
        }
    }
}