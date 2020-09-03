<template>
  <div class="Task" @dragstart="moveTask()" data-toggle="modal" data-target="#exampleModal">
    <div class="bg-secondary text-white border rounded mt-2">
      <div class="row justify-content-between ml-2 mt-1 mr-3">
        <h5 class="text-left">{{task.title}}</h5>
        <button @click="deleteTask(task._id)" class="btn btn-danger">Delete</button>
      </div>


      <div class="modal" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">Modal title</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
 <div>
      <comment
        class="task rounded mb-3 square bg-secondary text-light"
        v-for="commentItem in comments"
        :comment="commentItem"
        :key="commentItem.id"
      ></comment>
    </div>
      </div>
      <div class="modal-footer">
        <form @submit.prevent="addComment(task.id)">
        <div class="form-group">
          <label for="exampleInputEmail1"></label>
          <input
            v-model="newComment.content"
            type="text"
            class="form-control"
            id="createcomment"
            placeholder="Enter Comment"
          />
        </div>
        <Button type="submit" class="btn btn-block btn-success">Add</Button>
      </form>
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>

  
    </div>
   
  </div>

</template>

<script>
import Comment from "../components/Comment";
export default {
  name: "Task",
  props: ["task", "comment"],
  data() {
    return {
      newComment: {},
    };
  },
  mounted() {
    // this.$store.dispatch("getComments", this.task.id);
  },
  computed: {
    comments() {
      return this.task.comments;
    },
  },
  methods: {
    addComment(currentTaskId) {
      // let currentList = this.$store.state.lists.find(list => list.id == currentListId)
      this.$store.dispatch("addComment", {
        content: this.newComment.content,
        taskId: currentTaskId,
      });
      console.log("sent comment");
    },
    deleteTask(taskId) {
      // let task = this.$store.state.tasks.find(task => commentId == task.comments.includes(comment.commentId))
      this.$store.dispatch("deleteTask", taskId);
    },
    moveTask() {
      event.dataTransfer.setData("data", JSON.stringify(this.task));
      event.dataTransfer.setData("list", this.task.listId);
    },
  },
  components: {
    Comment,
  },
};
</script>


<style scoped>
</style>