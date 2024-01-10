using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Temel Model sınıfı
public class BaseModel
{
    public BaseController baseController; // Model'in bağlı olduğu BaseController

    // BaseModel'in yapıcı metodu
    public BaseModel(BaseController controller) {
        this.baseController = controller;
    }

    // BaseModel'in boş yapıcı metodu
    public BaseModel() {

    }

    // Model'in başlatılmasını sağlayan sanal metot
    public virtual void Init() {

    }
}
