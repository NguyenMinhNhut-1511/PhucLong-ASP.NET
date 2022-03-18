function handleClickMenuItem(e) {
    var slug = $(e.target).attr('catslug');
    var categoryContainer = $(`.order-center .category[catslug="${slug}"]`);
    $('html,body').animate({
        scrollTop: categoryContainer[0].offsetTop
    }, 'slow');
}

function handleClickBtnMenuMobile(e) {
    var target = $(e.target);
    if (target.hasClass('open')) {
        target.removeClass('open');
    } else {
        target.addClass('open');
    }
    $('.sidebar-left').toggle(300);
}

function handleClickExtendCart(e) {
    $('.cart-group-top').slideToggle(500);
}

function handleCollapseGroupItem(e) {
    var listProduct = $(e.target).next();
    listProduct.slideToggle();
}

var cat = [...document.querySelectorAll(".cat-item")]
for (var i = 0; i < cat.length; i++) {
    cat[i].addEventListener("click", function (e) {
        handleClickMenuItem(e)
    })
}

var catname = [...document.querySelectorAll(".category-name")]
for (var i = 0; i < catname.length; i++) {
    catname[i].addEventListener("click", function (e) {
        handleCollapseGroupItem(e)
    })
}

document.querySelector(".sidebar-right .cart-ss2").addEventListener("click", function (e) {
    handleClickExtendCart(e)
})

document.querySelector(".sidebar-right .arrow-down").addEventListener("click", function (e) {
    handleClickExtendCart(e)
})

// CODE
const $$ = document.querySelectorAll.bind(document)

function money(x) {
    return x.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
}

function _EditInfo(ID, tenSP, Gia, GiamGia, Anh) {
    document.querySelector("#nameSP").innerHTML = tenSP
    document.querySelector("#pp-product-name").innerHTML = tenSP
    document.querySelector("#pp-product-name").setAttribute("data-id", ID)
    document.querySelector("#pp-product-img").src = Anh
    if (GiamGia == 0) {
        var html = `
                            <div id="pp-product-price" class="price">`+ money(parseInt(Gia)).replace("VND", "đ") + `</div>
                        `
        document.querySelector(".ss-1-right .product-price").innerHTML = html
        document.querySelector("#pp-product-name").setAttribute("data-price", Gia)
    } else {
        var html = `
                            <div id="pp-product-price" class="price">`+ money(Gia * (100 - GiamGia) / 100).replace("VND", "đ") + `</div>
                            <div id="pp-product-regular-price" class="regular-price">`+ money(parseInt(Gia)).replace("VND", "đ") + `</div>
                        `
        document.querySelector(".ss-1-right .product-price").innerHTML = html
        document.querySelector("#pp-product-name").setAttribute("data-price", Gia * (100 - GiamGia) / 100)
    }
}

function _EditLoai(ChonLoai) {
    var json = JSON.parse(ChonLoai)
    var html = ""
    for (var i = 0; i < json.length; i++) {
        html += `
                                <label class="container-radio">
                                    <span>`+ json[i] + `</span>
                                    <input type="radio" `+ (i == 0 ? `checked` : ``) + ` value="` + json[i] + `" name="type">
                                        <span class="checkmark-radio"></span>
                                </label>`
    }
    document.querySelector(".type .customize-content").innerHTML = html;
}

function _EditSize(ChonSize) {
    var json = JSON.parse(ChonSize)
    var html = ""
    for (var i = 0; i < json.length; i++) {
        html += `
                                <label class="container-radio">
                                    <span>Size `+ json[i] + `</span>
                                    <input type="radio" `+ (i == 0 ? `checked` : ``) + ` value="` + json[i] + `" name="size">
                                    <span class="checkmark-radio"></span>
                                </label>`
    }
    document.querySelector(".size .customize-content").innerHTML = html;
}

function _EditDuong(ChonDuong) {
    var json = JSON.parse(ChonDuong)
    var html = ""
    for (var i = 0; i < json.length; i++) {
        html += `
                                <label class="container-radio">
                                    <span>`+ json[i] + `% đường</span>
                                    <input type="radio" `+ (i == 0 ? `checked` : ``) + ` name="sugar" value="` + json[i] + `">
                                    <span class="checkmark-radio"></span>
                                </label>`
    }
    document.querySelector(".sugar .customize-content").innerHTML = html;
}

function _EditDa(ChonDa) {
    var json = JSON.parse(ChonDa)
    var html = ""
    for (var i = 0; i < json.length; i++) {
        html += `
                                <label class="container-radio">
                                    <span>`+ json[i] + `% Đá</span>
                                    <input type="radio" `+ (i == 0 ? `checked` : ``) + ` name="ice" value="` + json[i] + `">
                                    <span class="checkmark-radio"></span>
                                </label>`
    }
    document.querySelector(".ice .customize-content").innerHTML = html;
}

function _GetTP(id, ListTP) {
    for (var i = 0; i < ListTP.length; i++) {
        if (ListTP[i].ID == id) {
            return ListTP[i];
        }
    }
    return false;
}

function _EditTopping(ChonTopping, ListTP) {
    var json = JSON.parse(ChonTopping)
    var html = ""
    for (var i = 0; i < json.length; i++) {
        var itemTP = _GetTP(json[i], ListTP)
        if (itemTP != false) {
            html += `
                        <div class="topping-wrap" data-price="`+ itemTP.Gia + `">
                            <label class="container-checkbox">
                                <span>`+ itemTP.tenTP + `</span>
                                <input type="checkbox" name="topping" value="`+ itemTP.ID + `">
                                <span class="checkmark"></span>
                            </label>
                            <span class="topping-price">+ `+ money(parseInt(itemTP.Gia)).replace("VND", "đ") + `</span>
                        </div>`
        }
    }
    document.querySelector(".topping .customize-content").innerHTML = html;
}

function _TinhGiaTP() {
    var giaTP = 0
    var listTP = [...document.querySelectorAll(".topping-wrap")]
    for (var i = 0; i < listTP.length; i++) {
        if (listTP[i].querySelector("input").checked) {
            var price = listTP[i].getAttribute("data-price")
            giaTP += parseInt(price)
        }
    }
    var giaSP = document.querySelector("#pp-product-name").getAttribute("data-price")
    document.querySelector("#pp-product-price").innerHTML = money(parseInt(giaSP) + parseInt(giaTP)).replace("VND", "đ")
}

const btnDatHang = [...$$('#DatHang')];
for (let i = 0; i < btnDatHang.length; i++) {
    btnDatHang[i].addEventListener("click", function (e) {
        var item = JSON.parse($(e.target).attr('data-item').replaceAll("\n", ""))
        document.querySelector(".change-quantity-wrap .amount").innerHTML = "1"
        document.querySelector
        var ID = item[0]
        var tenSP = item[1]
        var Gia = item[2]
        var GiamGia = item[3]
        var ChonLoai = item[4].replaceAll("'", "\"")
        var ChonSize = item[5].replaceAll("'", "\"")
        var ChonDuong = item[6].replaceAll("'", "\"")
        var ChonDa = item[7].replaceAll("'", "\"")
        var ChonTopping = item[8].replaceAll("'", "\"")
        var Anh = item[9]
        var ListTP = JSON.parse(item[10].replaceAll("'", "\""))
        _EditInfo(ID, tenSP, Gia, GiamGia, Anh)
        _EditLoai(ChonLoai)
        _EditSize(ChonSize)
        _EditDuong(ChonDuong)
        _EditDa(ChonDa)
        _EditTopping(ChonTopping, ListTP)
        var listControl = [...document.querySelectorAll(".topping-wrap input")]
        for (var i = 0; i < listControl.length; i++) {
            listControl[i].addEventListener("change", function (e) {
                _TinhGiaTP()
            })
        }
    })
}

document.querySelector(".change-quantity-wrap .increase").addEventListener("click", function (e) {
    var amount = document.querySelector(".change-quantity-wrap .amount").innerHTML;
    document.querySelector(".change-quantity-wrap .amount").innerHTML = (parseInt(amount) + 1);
})
document.querySelector(".change-quantity-wrap .decrease").addEventListener("click", function (e) {
    var amount = document.querySelector(".change-quantity-wrap .amount").innerHTML;
    if (amount > 1)
        document.querySelector(".change-quantity-wrap .amount").innerHTML = (parseInt(amount) - 1);
})
document.querySelector("#ThemGioHang").addEventListener("click", function (e) {
    var giaTP = 0
    var itemsTP = []
    var listTP = [...document.querySelectorAll(".topping-wrap")]
    for (var i = 0; i < listTP.length; i++) {
        if (listTP[i].querySelector("input").checked) {
            var price = listTP[i].getAttribute("data-price")
            itemsTP.push(listTP[i].querySelector("input").value)
            giaTP += parseInt(price)
        }
    }

    var Type = ""
    var listType = [...document.querySelectorAll(".type .container-radio")]
    for (var i = 0; i < listType.length; i++) {
        var input = listType[i].querySelector("input")
        if (input.checked) {
            Type = input.value
        }
    }

    var Size = ""
    var listSize = [...document.querySelectorAll(".size .container-radio")]
    for (var i = 0; i < listSize.length; i++) {
        var input = listSize[i].querySelector("input")
        if (input.checked) {
            Size = input.value
        }
    }

    var Duong = ""
    var listDuong = [...document.querySelectorAll(".sugar .container-radio")]
    for (var i = 0; i < listDuong.length; i++) {
        var input = listDuong[i].querySelector("input")
        if (input.checked) {
            Duong = input.value
        }
    }

    var Da = ""
    var listDa = [...document.querySelectorAll(".ice .container-radio")]
    for (var i = 0; i < listDa.length; i++) {
        var input = listDa[i].querySelector("input")
        if (input.checked) {
            Da = input.value
        }
    }
    var ID = document.querySelector("#pp-product-name").getAttribute("data-id")
    var SL = document.querySelector(".change-quantity-wrap .amount").innerHTML
    var Gia = document.querySelector("#pp-product-name").getAttribute("data-price")
    var employee = new Object();
    employee.ID = ID
    employee.SL = SL
    employee.Gia = parseInt(Gia) + parseInt(giaTP);
    employee.Loai = Type
    employee.Size = Size
    employee.Duong = Duong
    employee.Da = Da
    employee.ListTP = itemsTP
    employee.reURL = window.location.href
    $.ajax({
        type: "POST",
        url: "/GioHang/ThemGioHang",
        data: JSON.stringify(employee),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            location.reload()

        },
        error: function (response) {
            location.reload()
        }
    });

})