﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTodo {
    public class TodoTask {

        [JsonProperty("taskName")]
        private string taskName;

        [JsonProperty("IsCompleted")]
        public bool IsCompleted { get; private set; }

        public TodoTask(string taskName) {
            this.taskName = taskName;
        }
        [JsonConstructor]
        public TodoTask(string taskName,bool isCompleted) {
            this.taskName = taskName;
            this.IsCompleted = isCompleted;
        }

        public void Update(TodoTask task) {
            if (taskName != task.taskName) {
                taskName = task.taskName;
            }
        }

        public override bool Equals(object obj) {
            if (obj is TodoTask task) {
                return taskName.Equals(task.taskName);
            }

            return false;
        }

        public override string ToString() {
            return taskName;
        }

        public void Done() {
            IsCompleted = true;
        }

        public override int GetHashCode() {
            return 0;
        }
    }
}
